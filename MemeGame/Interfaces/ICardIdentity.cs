using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface ICardIdentity
    {
        /// <summary>
        /// Id of the card.
        /// </summary>
        ObjectId Id { get; }
    }
}
