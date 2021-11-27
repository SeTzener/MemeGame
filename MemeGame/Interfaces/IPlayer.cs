using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IPlayer : IPlayerInfos, IPlayerIdentity
    {

        IHand Hand { get; }
        int Points { get; }
        /// <summary>
        /// Select the card you want to win the round and assign a point to the player.
        /// </summary>
        void MakeYourChoice(ICardIdentity id);
    }
}
