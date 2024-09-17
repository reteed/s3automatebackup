using s3automatebackup.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace s3automatebackup.Services
{
    public class BackupService
    {
        private StorageService _storageService;
        private List<System.Threading.Timer> _timers = new();
        private bool _disposed = false;

        public BackupService()
        {
            _storageService = new StorageService();
        }

        public void ScheduleTasks()
        {
            List<BackupTask> tasks = _storageService.LoadTasks();
            foreach (BackupTask task in tasks)
            {
                ScheduleTask(task);
            }
        }

        private void ScheduleTask(BackupTask task)
        {
            // Dispose of existing timer for this task, if any
            if (task.Timer != null)
            {
                task.Timer.Dispose();
                _timers.Remove(task.Timer); // Remove the old timer
                task.Timer = null; // Explicitly clear the reference
            }

            DateTime scheduledTime = task.ScheduledTime;
            DateTime currentTime = DateTime.Now;

            // Schedule the next occurrence based on time logic
            if (currentTime > scheduledTime)
            {
                scheduledTime = GetNextOccurrence(task.PeriodKey, scheduledTime);
            }

            TimeSpan timeToGo = scheduledTime - currentTime;

            // Adjust for immediate execution if timeToGo is negative
            if (timeToGo < TimeSpan.Zero)
            {
                timeToGo = TimeSpan.Zero;
            }

            // Set the timer reference in the task
            task.Timer = new System.Threading.Timer(ExecuteTaskCallback, task, timeToGo, Timeout.InfiniteTimeSpan);
            _timers.Add(task.Timer);
        }

        private void ExecuteTaskCallback(object taskObject)
        {
            BackupTask task = (BackupTask)taskObject;

            // Perform the backup task.
            ExecuteTask(task);

            // Calculate the next occurrence based on the PeriodKey and current ScheduledTime.
            DateTime nextOccurrence = GetNextOccurrence(task.PeriodKey, task.ScheduledTime);

            // Update the task's ScheduledTime to the next occurrence.
            StorageService storageService = new();
            List<BackupTask> tasks = storageService.LoadTasks();
            BackupTask taskToFind = tasks.Find(t => t.Id == task.Id);
            if (taskToFind != null)
            {
                taskToFind.ScheduledTime = nextOccurrence;
                storageService.SaveTasks(tasks);
                // Reschedule the task for the next period.
                ScheduleTask(taskToFind);
            }
        }

        private DateTime GetNextOccurrence(int periodKey, DateTime lastOccurrence)
        {
            switch (periodKey)
            {
                case 1: // Daily
                    return lastOccurrence.AddDays(1);
                case 2: // Weekly
                    return lastOccurrence.AddDays(7);
                case 3: // Monthly
                    return lastOccurrence.AddMonths(1);
                case 4: // Yearly
                    return lastOccurrence.AddYears(1);
                default:
                    throw new InvalidOperationException("Invalid Period Key.");
            }
        }

        private async void ExecuteTask(BackupTask task)
        {
            Configuration config = task.Configuration;
            S3Service s3Service = new(config.Server, config.AccessKey, config.SecretKey, task.BucketName);

            s3Service.EnsureVersioningEnabled();

            // Remove old files and versions if needed
            await RemoveOldFilesAndVersions(task, s3Service);

            // Check if the path is a directory or a file
            if (File.Exists(task.BackupPath))
            {
                // It's a file; process this single file without hierarchy
                bool processed = await ProcessFile(
                    task.BackupPath,
                    s3Service,
                    task.Hierarchy ? Path.GetDirectoryName(task.BackupPath) : null,
                    task.Hierarchy
                );

                // Delete backed up file from local disk if required
                if (task.DeletePath && processed)
                {
                    File.Delete(task.BackupPath);
                }
                Console.WriteLine($"Backup task for {task.BucketName} executed.");
            }
            else if (Directory.Exists(task.BackupPath))
            {
                // It's a directory; process all files in the directory
                string[] localFiles = Directory.GetFiles(task.BackupPath, "*.*", SearchOption.AllDirectories);
                foreach (string localFilePath in localFiles)
                {
                    bool processed = await ProcessFile(
                        localFilePath,
                        s3Service,
                        task.Hierarchy ? task.BackupPath : null,
                        task.Hierarchy
                    );

                    // Delete backed up files from local disk if required
                    if (task.DeletePath && processed)
                    {
                        File.Delete(localFilePath);
                    }
                }
                Console.WriteLine($"Backup task for {task.BucketName} executed.");
            }
            else
            {
                Console.WriteLine($"The path does not exist: {task.BackupPath}");
            }
        }

        private async Task<bool> ProcessFile(string localFilePath, S3Service s3Service, string rootDirectory, bool hierarchy)
        {
            string fileName;

            if (hierarchy)
            {
                // Get the relative path from the root directory to maintain the full hierarchy
                fileName = GetRelativePath(localFilePath, rootDirectory);
            }
            else
            {
                // Just use the file name if hierarchy is not needed
                fileName = Path.GetFileName(localFilePath);
            }

            DateTime? fileExistsInS3 = await s3Service.DoesFileExist(fileName);

            if (fileExistsInS3 == null)
            {
                // File doesn't exist in the bucket, upload it
                bool uploaded = await s3Service.UploadFileAsync(localFilePath, fileName);
                return uploaded;
            }
            else
            {
                // File exists in the bucket, compare timestamps
                DateTime localLastModified = File.GetLastWriteTimeUtc(localFilePath);

                if (localLastModified > fileExistsInS3)
                {
                    // If the local file is newer, upload it to update the one in the bucket
                    bool uploaded = await s3Service.UploadFileAsync(localFilePath, fileName);
                    return uploaded;
                }
                else
                {
                    // No need to upload if the file in S3 is newer or the same
                    return false;
                }
            }
        }

        private async Task RemoveOldFilesAndVersions(BackupTask task, S3Service s3Service)
        {
            if (task.RemoveOldFiles && task.OldFilesDays > 0)
            {
                var files = await s3Service.ListAllObjects(task.BucketName);
                foreach (var file in files)
                {
                    if (file.LastModified.AddDays(task.OldFilesDays) < DateTime.Now)
                    {
                        // Get all versions of the file
                        var versions = await s3Service.GetObjectVersions(file.Key);
                        foreach (var version in versions)
                        {
                            await s3Service.DeleteVersion(file.Key, version.VersionId);
                        }
                        Console.WriteLine($"Deleted all versions of {file.Key} older than {task.OldFilesDays} days.");
                    }
                }
            }
        }

        private string GetRelativePath(string fullPath, string basePath)
        {
            // Ensure base path ends with a directory separator for proper comparison
            if (!basePath.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                basePath += Path.DirectorySeparatorChar;
            }

            // If fullPath starts with the basePath, strip it off to get the relative path
            if (fullPath.StartsWith(basePath, StringComparison.OrdinalIgnoreCase))
            {
                string relativePath = fullPath.Substring(basePath.Length);
                return relativePath.Replace(Path.DirectorySeparatorChar, '/'); // S3 uses '/' as a path separator
            }
            return fullPath.Replace(Path.DirectorySeparatorChar, '/');
        }
    }
}