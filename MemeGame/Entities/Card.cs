using MemeGame.DTO;
using MemeGame.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Entities
{
    public class Card : ICard
    {
        public Card(CardData data)
        {

        }
        public ObjectId Id => throw new NotImplementedException();
        public byte[] Image => throw new NotImplementedException();
        public string Text => throw new NotImplementedException();
        public bool IsQuestion => throw new NotImplementedException();
        public string MemeName => throw new NotImplementedException();
        public decimal ImageSize => throw new NotImplementedException();

    }
}
