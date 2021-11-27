using MemeGame.DB;
using MemeGame.DTO;
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
        public void DeckTest()
        {
            List<IPlayer> players = new List<IPlayer>() 
            { 
                new Player(new PlayerData(){ })
            };
            IRules rules = new Rules(new DTO.RulesData() { CardInHand = 7, MemeDeck = 15, QuestionDeck = 0 });
            IBoard board = new Board(players, rules, aws, db);
            
            
            Assert.IsTrue(board.MemeDeck.Count == 15);


        }
    }
}
