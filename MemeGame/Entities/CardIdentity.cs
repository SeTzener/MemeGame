using MemeGame.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Entities
{
    class CardIdentity : ICardIdentity
    {
        public ObjectId Id { get; set; }
    }
}
