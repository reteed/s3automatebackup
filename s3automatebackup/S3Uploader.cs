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

        public void UploadFile(string localFilePath, string s3Key)
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
                transferUtility.Upload(localFilePath, _bucketName, s3Key); // Added s3Key as the third parameter
                Console.WriteLine($"Successfully uploaded {localFilePath} to {_bucketName}/{s3Key}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task<DateTime?> DoesFileExist(string keyName)
        {
            var config = new AmazonS3Config
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };

            using var client = new AmazonS3Client(_accessKey, _secretKey, config);

            try
            {
                var request = new GetObjectMetadataRequest
                {
                    BucketName = _bucketName,
                    Key = keyName
                };

                GetObjectMetadataResponse response = await client.GetObjectMetadataAsync(request);
                if(response != null)
                {
                    return response.LastModified;
                }
                else
                {
                    return null;
                }
            }
            catch (AmazonS3Exception ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;
                throw; // Some other exception occurred, rethrow
            }
        }
    }
}