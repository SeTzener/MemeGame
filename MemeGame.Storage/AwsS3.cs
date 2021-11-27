using Amazon.S3;
using Amazon.S3.Model;
using MemeGame.Storage.Entities;
using MemeGame.Storage.Properties;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MemeGame.Storage
{
    public class AwsS3
    {
        private static AmazonS3Client _s3Client;
        public AwsS3(bool isTest = false)
        {
            this._IsTest = isTest;

            if (this._IsTest)
                this.Bucket = "gavizimemegametest";
            else
                this.Bucket = "gavizimemegame";

            AmazonS3Config config = new AmazonS3Config();

            config.ServiceURL = $"https://s3.eu-central-1.amazonaws.com";
            _s3Client = new AmazonS3Client(Resources.AwsAccess, Resources.AwsSecret, config);

            this.Folders = new StorageDisposition();
            this.Folders.ToStore = Resources.ToStoreFolder;
            this.Folders.StoredImages = Resources.StoredImagesFolder;
            this.Folders.StoredQuestions = Resources.StoredQuestionsFolder;
        }

        public string Bucket { get; set; }
        public StorageDisposition Folders { get; set; }
        private bool _IsTest { get; set; }

        public S3Object GetS3ObjectInfo()
        {
            S3Object s3Obj = new S3Object();

            try
            {
                ListObjectsRequest request = new ListObjectsRequest();
                request.BucketName = Bucket;

                s3Obj = _s3Client.ListObjectsAsync(request).GetAwaiter().GetResult().S3Objects.Where(x => !x.Key.EndsWith("/")).FirstOrDefault();

                if (s3Obj != null)
                    return s3Obj;
            }
            catch (Exception ex)
            {
                // TODO: gestire l'eccezione loggando da qualche parte
            }

            return null;
        }
        public S3Object GetS3ObjectInfo(string fileName)
        {
            S3Object s3Obj = new S3Object();

            try
            {
                ListObjectsRequest request = new ListObjectsRequest();
                request.BucketName = Bucket;

                s3Obj = _s3Client.ListObjectsAsync(request).GetAwaiter().GetResult().S3Objects.Where(x => x.Key.Contains(fileName) && !x.Key.EndsWith("/")).FirstOrDefault();

                if (s3Obj != null)
                    return s3Obj;
            }
            catch (Exception ex)
            {
                // TODO: gestire l'eccezione loggando da qualche parte
            }

            return null;
        }
        public bool MoveToBucket(string keySource, string keyTo, string fileName)
        {
            try
            {
                if (CopyFile(keySource, keyTo, fileName))
                {
                    if (DeleteFile(keySource, fileName))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public bool DeleteFile(string keySource, string fileName)
        {
            try
            {
                var requestDelete = new DeleteObjectRequest
                {
                    BucketName = this.Bucket,
                    Key = keySource + fileName
                };
                _s3Client.DeleteObjectAsync(requestDelete).Wait();
            }
            catch (Exception ex)
            {
                throw new Exception($"ERR-{DateTime.Now}: Something went wrong in the file delete.{Environment.NewLine}" +
                                    $"                    Check the method {System.Reflection.MethodBase.GetCurrentMethod().Name}{Environment.NewLine}" +
                                    $"                    {ex.Message}");
            }
            return true;
        }
        public bool CopyFile(string keySource, string keyTo, string fileName)
        {
            try
            {
                CopyObjectRequest requestCopy = new CopyObjectRequest
                {
                    SourceBucket = this.Bucket,
                    SourceKey = keySource + fileName,
                    DestinationBucket = this.Bucket,
                    DestinationKey = keyTo + fileName
                };
                _s3Client.CopyObjectAsync(requestCopy).Wait();
            }
            catch (Exception ex)
            {
                throw new Exception($"ERR-{DateTime.Now}: Something went wrong in the file copy.{Environment.NewLine}" +
                                    $"                    Check the method {System.Reflection.MethodBase.GetCurrentMethod().Name}{Environment.NewLine}" +
                                    $"                    {ex.Message}");
            }
            return true;
        }
        public async Task ListingObjectsAsync(string bucketName)
        {
            try
            {
                ListObjectsRequest request = new ListObjectsRequest()
                {
                    BucketName = bucketName,
                    MaxKeys = 5,
                };

                do
                {
                    ListObjectsResponse response = await _s3Client.ListObjectsAsync(request);

                    // Process the response.
                    response.S3Objects
                        .ForEach(obj => Console.WriteLine($"{obj.Key,-35}{obj.LastModified.ToShortDateString(),10}{obj.Size,10}"));

                    // If the response is truncated, set the marker to get the next
                    // set of keys.
                    if (response.IsTruncated)
                    {
                        request.Marker = response.NextMarker;
                    }
                    else
                    {
                        request = null;
                    }
                } while (request != null);
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error encountered on server. Message:'{ex.Message}' getting list of objects.");
            }
        }
        public byte[] GetS3Image(string s3Key)
        {
            try
            {
                using (GetObjectResponse response = _s3Client.GetObjectAsync(Bucket, s3Key).GetAwaiter().GetResult())
                {
                    // response.WriteResponseStreamToFileAsync(@"C:\Users\Gavizi\Desktop\Scrivania\MemeGame\prova2.jpeg", true, new System.Threading.CancellationToken());
                    return Tools.ReadStream(response.ResponseStream);
                }
            }
            catch (Exception ex)
            {
                // TODO: gestire l'eccezione loggando da qualche parte 
            }

            return null;
        }
    }
}
