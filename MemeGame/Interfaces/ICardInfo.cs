using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface ICardInfo
    {
        ObjectId Id { get; set; }
        string MemeName { get; set; }
        decimal ImageSize { get; set; }
    }
}
