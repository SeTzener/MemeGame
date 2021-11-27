using Amazon.S3.Model;
using MemeGame.DB.DTO;
using MemeGame.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using System.Collections.Generic;
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
        [TestMethod]
        public void GetRandomCards()
        {
            List<ObjectId> deck = db.Cards.GetRandomCards(10, false);
            Assert.AreEqual(deck.Count, 10);
            Assert.IsTrue(deck.GroupBy(x => x).Where(g => g.Count() > 1).Select(y => y.Key).ToList().Count == 0);

            deck = db.Cards.GetRandomCards(15, false);
            Assert.AreEqual(deck.Count, 15);
            Assert.IsTrue(deck.GroupBy(x => x).Where(g => g.Count() > 1).Select(y => y.Key).ToList().Count == 0);

            // TODO: Aggiungere pure i test con IsQuestion == true

            List<ObjectId> randomCard = db.Cards.GetRandomCards(false);
            Assert.IsNotNull(randomCard);
        }
        // [TestMethod]
        public void StoreCards()
        {
            int count = 0;
            while (db.Cards.Create())
            {
                count++;
            }
        }
    }
}
