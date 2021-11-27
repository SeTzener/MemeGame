using MemeGame.DB;
using MemeGame.Entities;
using MemeGame.Interfaces;
using MemeGame.Storage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.Test
{
    public class BoardTest
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
            List<IPlayer> players = null;
            IRules rules = new Rules()
            IBoard board = new Board(players,);


        }
    }
}
