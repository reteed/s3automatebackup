using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.IO;

namespace s3automatebackup.Services
{
    public class S3Service
    {
        public string _accessKey { get; set; }
        public string _secretKey { get; set; }
        public string _serviceUrl { get; set; }
        public string _bucketName { get; set; }

        public S3Service(string serviceUrl, string accessKey, string secretKey, string bucketName)
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
                if (response != null)
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

        public async Task<List<S3Object>> ListAllObjects(string bucketName)
        {
            var config = new AmazonS3Config
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };

            using var client = new AmazonS3Client(_accessKey, _secretKey, config);
            var request = new ListObjectsV2Request
            {
                BucketName = bucketName
            };

            var response = await client.ListObjectsV2Async(request);

            return response.S3Objects;
        }


        public async Task<List<S3ObjectVersion>> GetObjectVersions(string key)
        {
            var config = new AmazonS3Config
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };

            using var client = new AmazonS3Client(_accessKey, _secretKey, config);
            var request = new ListVersionsRequest
            {
                BucketName = _bucketName,
                Prefix = key
            };

            var response = await client.ListVersionsAsync(request);

            return response.Versions;
        }

        public async Task RestoreVersion(S3Object s3Object, string versionId)
        {
            var config = new AmazonS3Config
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };
            var request = new CopyObjectRequest
            {
                SourceBucket = _bucketName,
                SourceKey = s3Object.Key,
                SourceVersionId = versionId,
                DestinationBucket = _bucketName,
                DestinationKey = s3Object.Key
            };

            try
            {
                using var client = new AmazonS3Client(_accessKey, _secretKey, config);
                await client.CopyObjectAsync(request);
                Console.WriteLine($"Successfully restored version {versionId} of {s3Object.Key}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task<List<string>> ListAllBucketsAsync()
        {
            var config = new AmazonS3Config
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };

            using var client = new AmazonS3Client(_accessKey, _secretKey, config);
            var response = await client.ListBucketsAsync();

            List<string> buckets = new();
            foreach (var bucket in response.Buckets)
            {
                buckets.Add(bucket.BucketName);
            }

            return buckets;
        }
    }
}