using Amazon.S3;
using Amazon.S3.Model;
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
            if (isTest)
                this._bucket = "gavizimemegametest";
            else
                this._bucket = "gavizimemegame";
            AmazonS3Config config = new AmazonS3Config();


            config.ServiceURL = $"https://s3.eu-central-1.amazonaws.com";

            _s3Client = new AmazonS3Client(Properties.Resources.AwsAccess, Properties.Resources.AwsSecret, config);

        }
        private string _bucket { get; set; }
        private string _keySource { get; set; }


        public S3Object GetS3ObjectInfo()
        {
            S3Object s3Obj = new S3Object();

            try
            {
                ListObjectsRequest request = new ListObjectsRequest();
                request.BucketName = _bucket;
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

        public string SelectDestinationBucket(string key)
        {
            switch (key)
            {
                case "DaCaricare/":
                    this._keySource = key;
                    return "Meme/";

                default:
                    return "Meme/";
            }
        }

        public async Task<bool> MovetoConserved(string bucket, string keyTo)
        {
            try
            {

                CopyObjectRequest requestCopy = new CopyObjectRequest
                {
                    SourceBucket = bucket,
                    SourceKey = _keySource,
                    DestinationBucket = bucket,
                    DestinationKey = keyTo
                };
                _s3Client.CopyObjectAsync(requestCopy).Wait();

                var requestDelete = new DeleteObjectRequest
                {
                    BucketName = bucket,
                    Key = _keySource
                };
                await _s3Client.DeleteObjectAsync(requestDelete);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong into the copy/Delete file to Conserved.{Environment.NewLine}{ex.Message}");
            }
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
                using (GetObjectResponse response = _s3Client.GetObjectAsync(_bucket, s3Key).GetAwaiter().GetResult())
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
