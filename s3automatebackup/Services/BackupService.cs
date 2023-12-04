using s3automatebackup.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace s3automatebackup.Services
{
    public class BackupService : IDisposable
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
                _timers.Remove(task.Timer);
            }

            DateTime scheduledTime = task.ScheduledTime;
            DateTime currentTime = DateTime.Now;

            Configuration config = task.Configuration;
            S3Service s3Service = new S3Service(config.Server, config.AccessKey, config.SecretKey, task.BucketName);


            // Check if the scheduled time has passed and get next occurrence if needed.
            if (currentTime > scheduledTime)
            {
                scheduledTime = GetNextOccurrence(task.PeriodKey, scheduledTime);
            }

            TimeSpan timeToGo = scheduledTime - currentTime;

            // If the time to go is negative, set it to zero to execute immediately.
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

            // Calculate the next occurrence based on the PeriodKey.
            DateTime nextOccurrence = GetNextOccurrence(task.PeriodKey, DateTime.Now);

            // Update the task's ScheduledTime to the next occurrence.
            task.ScheduledTime = nextOccurrence;

            // Reschedule the task for the next period.
            ScheduleTask(task);
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
            S3Service s3Service = new S3Service(config.Server, config.AccessKey, config.SecretKey, task.BucketName);

            s3Service.EnsureVersioningEnabled();

            // Check if the path is a directory or a file
            if (File.Exists(task.BackupPath))
            {
                // It's a file; process this single file
                await ProcessFile(task.BackupPath, s3Service);
            }
            else if (Directory.Exists(task.BackupPath))
            {
                // It's a directory; process all files in the directory
                string[] localFiles = Directory.GetFiles(task.BackupPath, "*.*", SearchOption.AllDirectories);
                foreach (string localFilePath in localFiles)
                {
                    await ProcessFile(localFilePath, s3Service);
                }
            }
            else
            {
                Console.WriteLine($"The path does not exist: {task.BackupPath}");
            }

            Console.WriteLine($"Backup task for {task.BucketName} executed.");
        }

        private async Task ProcessFile(string localFilePath, S3Service s3Service)
        {
            string relativePath = GetRelativePath(localFilePath, Path.GetDirectoryName(localFilePath));

            DateTime? fileExistsInS3 = await s3Service.DoesFileExist(relativePath);

            if (fileExistsInS3 == null)
            {
                // File doesn't exist in the bucket, upload it
                await s3Service.UploadFileAsync(localFilePath, relativePath);
            }
            else
            {
                // File exists in the bucket, compare timestamps
                DateTime localLastModified = File.GetLastWriteTimeUtc(localFilePath);

                if (localLastModified > fileExistsInS3)
                {
                    // If the local file is newer, upload it to update the one in the bucket
                    await s3Service.UploadFileAsync(localFilePath, relativePath);
                }
            }
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).
                    foreach (System.Threading.Timer timer in _timers)
                    {
                        timer?.Dispose();
                    }
                    _timers.Clear();
                }

                _disposed = true;
            }
        }

        ~BackupService()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private string GetRelativePath(string fullPath, string basePath)
        {
            string lastDirectoryName = Path.GetFileName(basePath);

            if (!basePath.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                basePath += Path.DirectorySeparatorChar;
            }

            if (fullPath.StartsWith(basePath, StringComparison.OrdinalIgnoreCase))
            {
                string relativePath = fullPath.Substring(basePath.Length);
                return Path.Combine(lastDirectoryName, relativePath).Replace(Path.DirectorySeparatorChar, '/');
            }
            return fullPath.Replace(Path.DirectorySeparatorChar, '/');
        }
    }
}