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
            string bucket = "";

            if (isTest)
                bucket = "gavizimemegametest";
            else
                bucket = "gavizimemegame";
            AmazonS3Config config = new AmazonS3Config();


            config.ServiceURL = $"https://s3.eu-central-1.amazonaws.com";

            _s3Client = new AmazonS3Client(Properties.Resources.AwsAccess, Properties.Resources.AwsSecret, config);

        }
        public S3Object GetS3ObjectToConserve()
        {
            S3Object s3Obj = new S3Object();
            try
            {
                ListObjectsRequest request = new ListObjectsRequest();
                request.BucketName = "gavizimemegametest";
                s3Obj = _s3Client.ListObjectsAsync(request).GetAwaiter().GetResult().S3Objects.Where(x => !x.Key.EndsWith("/")).FirstOrDefault();
                using (GetObjectResponse response = _s3Client.GetObjectAsync("", "").GetAwaiter().GetResult())
                {
                    // byte[] s = response.ResponseStream.ReadByte();

                }
                if (s3Obj != null)
                {
                    return s3Obj;
                }
            }
            catch (Exception ex)
            {
                // TODO: gestire l'eccezione loggando da qualche parte e restituendo null
            }

            return null;
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

        public void DaAssegnare()
        {

            //GetObjectResponse response = _s3Client.GetObjectAsync(request);
            //using (Stream responseStream = response.ResponseStream)
            //{
            //    var bytes = ReadStream(responseStream);
            //    var download = new FileContentResult(bytes, "application/pdf");
            //    download.FileDownloadName = filename;
            //    return download;
            //}
        }
        public static byte[] ReadStream(Stream responseStream)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
