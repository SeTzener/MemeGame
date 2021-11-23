using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IPlayerIdentity
    {
        ObjectId PlayerId { get; }
    }
}
