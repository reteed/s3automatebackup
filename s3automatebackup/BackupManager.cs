using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3AutomateBackup
{
    using System.Timers;

    public class BackupManager
    {
        private Timer _backupTimer;
        private string _backupFolderPath;
        private S3Uploader _s3Uploader;

        public BackupManager(string backupFolderPath, S3Uploader s3Uploader, double intervalMilliseconds)
        {
            _backupFolderPath = backupFolderPath;
            _s3Uploader = s3Uploader;

            _backupTimer = new Timer(intervalMilliseconds);
            _backupTimer.Elapsed += PerformBackup;
            _backupTimer.AutoReset = true;
            _backupTimer.Enabled = true;
        }

        private void PerformBackup(object sender, ElapsedEventArgs e)
        {
            try
            {
                _s3Uploader.EnsureVersioningEnabled();
                _s3Uploader.UploadDirectory(_backupFolderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}