using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.DB
{
    public class Tools
    {
        private static AmazonS3Client _s3Client;
        public Tools(bool isTest=false)
        {
            string bucket = "";

            if (isTest)
                bucket = "gavizimemegametest";
            else
                bucket = "gavizimemegame";
            AmazonS3Config config = new AmazonS3Config();
            
            
            config.ServiceURL = $"https://{bucket}.s3.eu-central-1.amazonaws.com";

            _s3Client = new AmazonS3Client(Properties.Resources.AwsAccess, Properties.Resources.AwsSecret, config);
            
        }
        public bool RelocateImage()
        {
            
            try
            {

            PutBucketRequest requesttest = new PutBucketRequest();
                requesttest.BucketName = "new-bucket";
                requesttest.UseClientRegion = true;

                var createResponse = _s3Client.PutBucketAsync(requesttest).GetAwaiter().GetResult();


                ListBucketsResponse response = _s3Client.ListBucketsAsync().Result;
            ListObjectsRequest request = new ListObjectsRequest();
            request.BucketName = "DaCaricare";
            ListObjectsResponse response2 = _s3Client.ListObjectsAsync(request).GetAwaiter().GetResult();
           
            var prova2 = _s3Client.ListObjectsAsync("gavizimemegametest/DaCaricare").Result;
            }
            catch(Exception ex)
            {

            }

            return true;
        }
    }
}
