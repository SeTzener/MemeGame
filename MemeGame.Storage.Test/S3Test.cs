using Amazon.S3;
using NUnit.Framework;

namespace MemeGame.Storage.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            AwsS3 aws = new AwsS3(true);

            var s3Obj = aws.GetS3ObjectToStore();
            Assert.Pass();
        }
    }
}