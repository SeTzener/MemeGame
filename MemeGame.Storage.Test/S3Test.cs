using Amazon.S3;
using Amazon.S3.Model;
using NUnit.Framework;

namespace MemeGame.Storage.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            aws = new AwsS3(true);
        }

        AwsS3 aws;

        [Test]
        public void RetrievingAnItemToStore()
        {

            S3Object s3Obj = aws.GetS3ObjectInfo();

            Assert.IsNotNull(s3Obj);
            Assert.IsTrue(s3Obj.BucketName == "gavizimemegametest");
            Assert.IsTrue(s3Obj.Key == "ToStore/MemeTestImage.jpeg");
        }

        [Test]
        public void GetS3ImageBytes()
        {
            string s3Key = "ToStore/MemeTestImage.jpeg";

            byte[] image = aws.GetS3Image(s3Key);

            Assert.IsNotNull(image);
            Assert.IsTrue(image.Length == 52011);
        }

        [Test]
        public void CrudS3Test()
        {
            string bucketName = "gavizimemegametest";
            string keySource = "ToStore/";
            string KeyTo = "Meme/";
            string fileName = "MemeTestImage.jpeg";

            //aws.
        }
    }
}