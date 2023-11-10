using s3automatebackup.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace s3automatebackup.Services
{
    public class BackupService : IDisposable
    {
        private StorageService _storageService;
        private S3Service _s3Service;
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
                case 0: // Daily
                    return lastOccurrence.AddDays(1);
                case 1: // Monthly
                    return lastOccurrence.AddMonths(1);
                case 2: // Yearly
                    return lastOccurrence.AddYears(1);
                default:
                    throw new InvalidOperationException("Invalid Period Key.");
            }
        }

        private void ExecuteTask(BackupTask task)
        {
            // Create a new S3Service instance for the task using its configuration.
            Configuration config = task.Configuration;
            S3Service s3Service = new S3Service(config.Server, config.AccessKey, config.SecretKey, task.BucketName);

            // Perform the backup task using the task's specific S3Service instance.
            s3Service.UploadFile(task.BackupFolder, task.BucketName);
            Console.WriteLine($"Backup task for {task.BucketName} executed.");
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
    }
}