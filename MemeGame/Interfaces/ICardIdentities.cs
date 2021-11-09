using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface ICardIdentities
    {
        ObjectId Id { get; }
    }
}
