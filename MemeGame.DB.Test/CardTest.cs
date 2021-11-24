using Amazon.S3.Model;
using MemeGame.DB.DTO;
using MemeGame.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using System.Linq;
using System.Threading;

namespace MemeGame.DB.Test
{
    [TestClass]
    public class CardTest
    {
        public DbOperations db { get; set; }
        public AwsS3 aws { get; set; }
        public CardTest()
        {
            db = new DbOperations(true);
            aws = new AwsS3(true);
        }
        [TestMethod]
        public void AddCard()
        {
            Assert.IsTrue(db.Cards.Create());
            Card card = db.Cards.Find("MemeTestImage");
            Assert.IsNotNull(card);
            Assert.AreEqual(card.S3Key, "Meme/");

            Thread.Sleep(2 * 1000);
            S3Object info = aws.GetS3ObjectInfo("MemeTestImage");
            Assert.AreEqual(info.Key, "Meme/MemeTestImage.jpeg");

            aws.MoveToBucket("Meme/", "ToStore/", "MemeTestImage.jpeg");

            Thread.Sleep(2 * 1000);
            info = aws.GetS3ObjectInfo("MemeTestImage");
            Assert.AreEqual(info.Key, "ToStore/MemeTestImage.jpeg");

            db.Cards.Delete("MemeTestImage");
            card = db.Cards.Find("MemeTestImage");
            Assert.IsNull(card);
        }
    }
}
