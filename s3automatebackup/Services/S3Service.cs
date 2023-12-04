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
            AmazonS3Config config = new()
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };
            using AmazonS3Client client = new(_accessKey, _secretKey, config);
            PutBucketVersioningRequest request = new()
            {
                BucketName = _bucketName,
                VersioningConfig = new()
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

        public async Task<bool> UploadFileAsync(string localFilePath, string s3Key)
        {
            AmazonS3Config config = new()
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };
            using AmazonS3Client client = new(_accessKey, _secretKey, config);
            using TransferUtility transferUtility = new(client);
            try
            {
                await transferUtility.UploadAsync(localFilePath, _bucketName, s3Key);
                Console.WriteLine($"Successfully uploaded {localFilePath} to {_bucketName}/{s3Key}.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public async Task<DateTime?> DoesFileExist(string keyName)
        {
            AmazonS3Config config = new()
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };
            using AmazonS3Client client = new(_accessKey, _secretKey, config);
            try
            {
                GetObjectMetadataRequest request = new()
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
                throw;
            }
        }

        public async Task<List<S3Object>> ListAllObjects(string bucketName)
        {
            AmazonS3Config config = new()
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };
            using AmazonS3Client client = new(_accessKey, _secretKey, config);
            ListObjectsV2Request request = new()
            {
                BucketName = bucketName
            };
            ListObjectsV2Response response = await client.ListObjectsV2Async(request);
            return response.S3Objects;
        }


        public async Task<List<S3ObjectVersion>> GetObjectVersions(string key)
        {
            AmazonS3Config config = new()
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };
            using AmazonS3Client client = new(_accessKey, _secretKey, config);
            ListVersionsRequest request = new()
            {
                BucketName = _bucketName,
                Prefix = key
            };

            ListVersionsResponse response = await client.ListVersionsAsync(request);
            return response.Versions;
        }

        public async Task RestoreVersion(S3Object s3Object, string versionId)
        {
            AmazonS3Config config = new()
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };
            CopyObjectRequest request = new()
            {
                SourceBucket = _bucketName,
                SourceKey = s3Object.Key,
                SourceVersionId = versionId,
                DestinationBucket = _bucketName,
                DestinationKey = s3Object.Key
            };

            try
            {
                using AmazonS3Client client = new(_accessKey, _secretKey, config);
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
            AmazonS3Config config = new()
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };
            using AmazonS3Client client = new(_accessKey, _secretKey, config);
            ListBucketsResponse response = await client.ListBucketsAsync();

            List<string> list = [];
            List<string> buckets = list;
            foreach (S3Bucket bucket in response.Buckets)
            {
                buckets.Add(bucket.BucketName);
            }
            return buckets;
        }
    }
}