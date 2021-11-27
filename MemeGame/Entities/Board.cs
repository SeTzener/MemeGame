using MemeGame.DB;
using MemeGame.Interfaces;
using MemeGame.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemeGame.Entities
{
    public class Board : IBoard
    {
        private DbOperations _data { get; set; }
        private AwsS3 _storage { get; set; }
        public Board(List<IPlayer> players, IRules rules, AwsS3 storage, DbOperations db)
        {
            _data = db;
            _storage = storage;
            this.Players = players;
            this.MemeDeck = AssembleDeck(rules.MemeDeck, false);
            this.QuestionDeck = AssembleDeck(rules.QuestionDeck , true);
            this.DiscardPile = new List<ICardIdentity>();
        }
        public List<IPlayer> Players { get; private set; }

        public List<ICardIdentity> QuestionDeck { get; private set; }

        public List<ICardIdentity> MemeDeck { get; private set; }

        public List<ICardIdentity> DiscardPile { get; private set; }

        public IPlayground Playground { get; private set; }

        public decimal Timer { get; private set; }

        public int BoardId { get; private set; }

        public List<ICardIdentity> AssembleDeck(int n, bool isQuestion)
        {
            return _data.Cards.GetRandomCards(n, isQuestion).Cast<ICardIdentity>().ToList();
        }

        public decimal TimeCount()
        {
            throw new NotImplementedException();
        }
    }
}
