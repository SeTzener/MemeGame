using MemeGame.DB;
using MemeGame.Interfaces;
using MemeGame.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Entities
{
    public class Board : IBoard
    {
        public Board(List<IPlayer> players, IRules rules, AwsS3 storage, DbOperations db)
        {
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
            throw new NotImplementedException();
        }

        public decimal TimeCount()
        {
            throw new NotImplementedException();
        }
    }
}
