using MemeGame.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Entities
{
    public class Hand : IHand
    {
        public List<ICard> Cards { get; private set; }

        public ICardInfos Discard()
        {
            throw new NotImplementedException();
        }

        public ICardInfos Discard(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public ICardInfos Discard(List<ObjectId> ids)
        {
            throw new NotImplementedException();
        }

        public ICard DrawCard()
        {
            throw new NotImplementedException();
        }

        public ICard DrawCard(int n)
        {
            throw new NotImplementedException();
        }

        public ICard PlayCard()
        {
            throw new NotImplementedException();
        }
    }
}
