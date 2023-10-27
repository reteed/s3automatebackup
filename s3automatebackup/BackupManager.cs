using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3AutomateBackup
{
    using Amazon.S3.Model;
    using Amazon.S3;
    using System.Timers;

    public class BackupManager
    {
        private Timer _backupTimer;
        private string _backupFolderPath;
        private S3Service _s3Service;

        public BackupManager(string backupFolderPath, S3Service s3Service, double intervalMilliseconds, bool first)
        {
            _backupFolderPath = backupFolderPath;
            _s3Service = s3Service;
            if (first)
            {
                PerformBackup(null, null);
            }
            else
            {
                _backupTimer = new Timer(intervalMilliseconds);
                _backupTimer.Elapsed += PerformBackup;
                _backupTimer.AutoReset = true;
                _backupTimer.Enabled = true;
            }
        }

        private async void PerformBackup(object sender, ElapsedEventArgs e)
        {
            try
            {
                _s3Service.EnsureVersioningEnabled();
                string[] localFiles = Directory.GetFiles(_backupFolderPath, "*.*", SearchOption.AllDirectories);

                foreach (string localFilePath in localFiles)
                {
                    // Calculate the relative path of the file from the backup folder
                    string relativePath = GetRelativePath(localFilePath, _backupFolderPath);


                    // Use the DoesFileExist method to check if the file exists in the S3 bucket
                    DateTime? fileExistsInS3 = await _s3Service.DoesFileExist(relativePath);

                    if (fileExistsInS3 == null)
                    {
                        // File doesn't exist in the bucket, upload it
                        _s3Service.UploadFile(localFilePath, relativePath);
                    }
                    else
                    {
                        // File exists in the bucket, compare timestamps
                        DateTime localLastModified = File.GetCreationTimeUtc(localFilePath);

                        // If the local file is newer, upload it to update the one in the bucket
                        if (localLastModified > fileExistsInS3)
                        {
                            _s3Service.UploadFile(localFilePath, relativePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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