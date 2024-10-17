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
using s3automatebackup.Forms;
using System.IO.Compression;
using System.Security.Cryptography;

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

        public async Task<bool> UploadFileAsync(string localFilePath, string s3Key, bool isEncrypted = false)
        {
            // Check if the file is locked
            if (IsFileLocked(localFilePath))
            {
                Console.WriteLine($"The file {localFilePath} is currently being used by another process. Please try again later.");
                return false;
            }

            AmazonS3Config config = new()
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };

            using AmazonS3Client client = new(_accessKey, _secretKey, config);
            FileInfo fileInfo = new FileInfo(localFilePath);
            long maxSingleUploadSize = 5 * 1024 * 1024 * 1024L; // 5 GB

            // Modify the key to add .enc extension if the file is encrypted
            if (isEncrypted)
            {
                s3Key += ".enc";
            }

            try
            {
                PutObjectRequest request = new PutObjectRequest
                {
                    BucketName = _bucketName,
                    Key = s3Key,
                    FilePath = localFilePath
                };

                // Check if file size is larger than 5 GB for multi-part upload
                if (fileInfo.Length > maxSingleUploadSize)
                {
                    await CustomMultiPartUploadAsync(client, localFilePath, s3Key); // For large files
                }
                else
                {
                    await client.PutObjectAsync(request); // For smaller files
                }

                Console.WriteLine($"Successfully uploaded {localFilePath} to {_bucketName}/{s3Key}.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        private async Task CustomMultiPartUploadAsync(AmazonS3Client client, string localFilePath, string s3Key)
        {
            const int chunkSize = 5 * 1024 * 1024; // Chunk size is 5 MB
            List<PartETag> partETags = new List<PartETag>();
            string uploadId = null;

            try
            {
                // Check if the file is locked
                if (IsFileLocked(localFilePath))
                {
                    Console.WriteLine($"The file {localFilePath} is currently being used by another process. Cannot upload.");
                    return;
                }

                // Initialize the multi-part upload
                var initiateResponse = await client.InitiateMultipartUploadAsync(new InitiateMultipartUploadRequest
                {
                    BucketName = _bucketName,
                    Key = s3Key
                });
                uploadId = initiateResponse.UploadId;

                // Upload the parts
                using (FileStream fileStream = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
                {
                    int partNumber = 1;
                    for (long filePosition = 0; filePosition < fileStream.Length; filePosition += chunkSize, partNumber++)
                    {
                        var currentPartSize = Math.Min(chunkSize, fileStream.Length - filePosition);
                        var buffer = new byte[currentPartSize];
                        await fileStream.ReadAsync(buffer, 0, (int)currentPartSize);

                        var uploadPartResponse = await client.UploadPartAsync(new UploadPartRequest
                        {
                            BucketName = _bucketName,
                            Key = s3Key,
                            UploadId = uploadId,
                            PartNumber = partNumber,
                            InputStream = new MemoryStream(buffer)
                        });

                        partETags.Add(new PartETag { PartNumber = partNumber, ETag = uploadPartResponse.ETag });
                    }
                }

                // Complete the multi-part upload
                await client.CompleteMultipartUploadAsync(new CompleteMultipartUploadRequest
                {
                    BucketName = _bucketName,
                    Key = s3Key,
                    UploadId = uploadId,
                    PartETags = partETags
                });
                Console.WriteLine($"Successfully completed multi-part upload for {localFilePath} to {_bucketName}/{s3Key}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the multi-part upload: {ex.Message}");
                if (uploadId != null)
                {
                    // Abort the multi-part upload
                    await client.AbortMultipartUploadAsync(new AbortMultipartUploadRequest
                    {
                        BucketName = _bucketName,
                        Key = s3Key,
                        UploadId = uploadId
                    });
                    Console.WriteLine($"Aborted multi-part upload for {localFilePath} due to an error.");
                }
                throw;
            }
        }

        public bool IsFileLocked(string filePath)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                // The file is locked
                return true;
            }

            // The file is not locked
            return false;
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

                // Return the last modified date if the object exists
                return response.LastModified;
            }
            catch (AmazonS3Exception ex)
            {
                // If the file is not found, return null and log a message instead of crashing
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"File with key {keyName} does not exist in bucket {_bucketName}.");
                    return null; // Indicating that the file doesn't exist
                }
                // Rethrow other exceptions if they aren't handled specifically
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

        public event Action OnDeletionCompleted;

        public async Task DeleteAllObjectsAndVersions(string bucketName)
        {
            AmazonS3Config config = new()
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };
            using AmazonS3Client client = new(_accessKey, _secretKey, config);

            // List all object versions in the bucket
            ListVersionsRequest listVersionsRequest = new()
            {
                BucketName = bucketName
            };

            ListVersionsResponse listVersionsResponse;
            do
            {
                listVersionsResponse = await client.ListVersionsAsync(listVersionsRequest);

                // Create a list of objects to delete
                foreach (S3ObjectVersion version in listVersionsResponse.Versions)
                {
                    DeleteObjectRequest deleteObjectRequest = new()
                    {
                        BucketName = bucketName,
                        Key = version.Key,
                        VersionId = version.VersionId
                    };

                    await client.DeleteObjectAsync(deleteObjectRequest);
                    Console.WriteLine($"Deleted {version.Key} with version {version.VersionId}");
                }

                // Set the marker to continue listing
                listVersionsRequest.KeyMarker = listVersionsResponse.NextKeyMarker;
                listVersionsRequest.VersionIdMarker = listVersionsResponse.NextVersionIdMarker;

            } while (listVersionsResponse.IsTruncated);

            Console.WriteLine($"All objects and versions from bucket {bucketName} have been deleted.");

            // Notify that deletion is completed
            OnDeletionCompleted?.Invoke();
        }

        public async Task DownloadVersion(string key, string versionId, string downloadPath)
        {
            AmazonS3Config config = new()
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };

            using AmazonS3Client client = new(_accessKey, _secretKey, config);
            GetObjectRequest request = new()
            {
                BucketName = _bucketName,
                Key = key,
                VersionId = versionId
            };

            try
            {
                GetObjectResponse response = await client.GetObjectAsync(request);
                await response.WriteResponseStreamToFileAsync(downloadPath, false, default);
                Console.WriteLine($"Downloaded version {versionId} of {key} to {downloadPath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while downloading: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteVersion(string key, string versionId)
        {
            AmazonS3Config config = new()
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };

            using AmazonS3Client client = new(_accessKey, _secretKey, config);
            DeleteObjectRequest request = new()
            {
                BucketName = _bucketName,
                Key = key,
                VersionId = versionId
            };

            try
            {
                await client.DeleteObjectAsync(request);
                Console.WriteLine($"Deleted version {versionId} of {key}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting: {ex.Message}");
                throw;
            }
        }

        public async Task<GetObjectMetadataResponse> GetFileMetadataAsync(string keyName, string versionId = null)
        {
            AmazonS3Config config = new()
            {
                ServiceURL = _serviceUrl,
                ForcePathStyle = true
            };

            using AmazonS3Client client = new(_accessKey, _secretKey, config);

            try
            {
                GetObjectMetadataRequest request = new GetObjectMetadataRequest
                {
                    BucketName = _bucketName,
                    Key = keyName,
                    VersionId = versionId
                };

                return await client.GetObjectMetadataAsync(request);
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task DownloadBucketAsZipAsync(string downloadPath)
        {
            // Temporary directory for downloading the S3 bucket content
            string tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);

            string privateKey = null; // This will store the private key
            bool isPrivateKeyRequested = false; // Flag to track if the key has been requested

            // List all objects in the S3 bucket
            List<S3Object> s3Objects = await ListAllObjects(_bucketName);

            foreach (S3Object s3Object in s3Objects)
            {
                // Get the latest version of the object
                List<S3ObjectVersion> versions = await GetObjectVersions(s3Object.Key);
                S3ObjectVersion latestVersion = versions.OrderByDescending(v => v.LastModified).FirstOrDefault();

                if (latestVersion != null)
                {
                    // Determine the local file path (preserve hierarchy)
                    string localFilePath = Path.Combine(tempDirectory, s3Object.Key.Replace("/", "\\"));

                    // Ensure the directory structure exists
                    string localDirectory = Path.GetDirectoryName(localFilePath);
                    if (!Directory.Exists(localDirectory))
                    {
                        Directory.CreateDirectory(localDirectory);
                    }

                    // Download the latest version of the object
                    await DownloadVersion(s3Object.Key, latestVersion.VersionId, localFilePath);

                    // Check if the file is encrypted (.enc extension)
                    if (s3Object.Key.EndsWith(".enc", StringComparison.OrdinalIgnoreCase))
                    {
                        // Ask for the private key once if it hasn't been requested yet
                        if (!isPrivateKeyRequested)
                        {
                            using (PrivateKeyForm privateKeyForm = new PrivateKeyForm())
                            {
                                if (privateKeyForm.ShowDialog() == DialogResult.OK)
                                {
                                    privateKey = privateKeyForm.PrivateKey;
                                    isPrivateKeyRequested = true;
                                }
                                else
                                {
                                    MessageBox.Show("Private key is required to decrypt the files.", "Decryption Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return; // Exit if the user cancels the private key entry
                                }
                            }
                        }

                        // Decrypt the file
                        string decryptedFilePath = localFilePath.Replace(".enc", "");
                        bool decrypted = DecryptFile(localFilePath, decryptedFilePath, privateKey);

                        if (decrypted)
                        {
                            // Delete the encrypted file and keep the decrypted version
                            File.Delete(localFilePath);
                            localFilePath = decryptedFilePath; // Use the decrypted file for zipping
                        }
                        else
                        {
                            MessageBox.Show($"Failed to decrypt {localFilePath}.", "Decryption Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Stop the operation if decryption fails
                        }
                    }
                }
            }

            // Create a zip file from the downloaded directory
            string zipFilePath = Path.Combine(downloadPath, $"{_bucketName}_backup_{DateTime.Now:yyyyMMdd_HHmmss}.zip");
            ZipFile.CreateFromDirectory(tempDirectory, zipFilePath);

            // Clean up the temporary directory
            Directory.Delete(tempDirectory, true);

            Console.WriteLine($"Bucket content downloaded and zipped at: {zipFilePath}");
        }

        private bool DecryptFile(string inputFilePath, string outputFilePath, string decryptionKey)
        {
            try
            {
                using (FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                using (Aes aes = Aes.Create())
                {
                    // Derive key and IV from the decryption key using a salt (e.g., PBKDF2)
                    var key = new Rfc2898DeriveBytes(decryptionKey, Encoding.UTF8.GetBytes("S3EncryptSalt"), 10000);
                    aes.Key = key.GetBytes(32);  // AES-256
                    aes.IV = key.GetBytes(16);   // AES block size is 16 bytes

                    using (CryptoStream cryptoStream = new CryptoStream(inputFileStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            outputFileStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }

                return true; // Decryption successful
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Decryption failed: {ex.Message}");
                return false; // Decryption failed
            }
        }
    }
}