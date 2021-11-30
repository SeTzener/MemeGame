using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IPlayer : IPlayerInfos, IPlayerIdentity
    {
        /// <summary>
        /// Cards in the player's hand and related actions.
        /// </summary>
        IHand Hand { get; }
        /// <summary>
        /// Current game points.
        /// </summary>
        int Points { get; }
        /// <summary>
        /// Select the card you want to win the round and assign a point to the player.
        /// </summary>
        void MakeYourChoice(ICardIdentity id);
    }
}
