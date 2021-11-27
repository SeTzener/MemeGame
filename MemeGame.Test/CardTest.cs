using MemeGame.DB;
using MemeGame.Storage;
using MongoDB.Bson;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MemeGame.Test
{
    public class Tests
    {
        public DbOperations db { get; set; }
        public AwsS3 aws { get; set; }
        [SetUp]
        public void Setup()
        {
            db = new DbOperations(true);
            aws = new AwsS3(true);
        }

        [Test]
        public void ArrangeDeck()
        {
            


        }
    }
}