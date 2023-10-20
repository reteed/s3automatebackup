using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3AutomateBackup
{
    using Amazon.S3;
    using Amazon.S3.Model;
    using Amazon.S3.Transfer;
    using System;
    using System.IO;

    public class S3Uploader
    {
        private string _accessKey;
        private string _secretKey;
        private string _serviceUrl;
        private string _bucketName;

        public S3Uploader(string serviceUrl, string accessKey, string secretKey, string bucketName)
        {
            _accessKey = accessKey;
            _secretKey = secretKey;
            _serviceUrl = serviceUrl;
            _bucketName = bucketName;
        }

        public async void EnsureVersioningEnabled()
        {
            var config = new AmazonS3Config
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };

            using var client = new AmazonS3Client(_accessKey, _secretKey, config);

            var request = new PutBucketVersioningRequest
            {
                BucketName = _bucketName,
                VersioningConfig = new S3BucketVersioningConfig
                {
                    Status = VersionStatus.Enabled
                }
            };

            try
            {
                await client.PutBucketVersioningAsync(request);
                Console.WriteLine($"Versioning enabled for bucket {_bucketName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void UploadFile(string filePath)
        {
            var config = new AmazonS3Config
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };

            using var client = new AmazonS3Client(_accessKey, _secretKey, config);
            using var transferUtility = new TransferUtility(client);

            try
            {
                transferUtility.Upload(filePath, _bucketName);
                Console.WriteLine($"Successfully uploaded {filePath} to bucket {_bucketName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void UploadDirectory(string directoryPath)
        {
            var config = new AmazonS3Config
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };

            using var client = new AmazonS3Client(_accessKey, _secretKey, config);
            using var transferUtility = new TransferUtility(client);

            try
            {
                var transferUtilityRequest = new TransferUtilityUploadDirectoryRequest
                {
                    BucketName = _bucketName,
                    Directory = directoryPath,
                    SearchOption = SearchOption.AllDirectories, // This will ensure all subdirectories are included
                    KeyPrefix = Path.GetFileName(directoryPath)  // This can be adjusted as needed
                };

                transferUtility.UploadDirectory(transferUtilityRequest);
                Console.WriteLine($"Successfully uploaded directory {directoryPath} to bucket {_bucketName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}