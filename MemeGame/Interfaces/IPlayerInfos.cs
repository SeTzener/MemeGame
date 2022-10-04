using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IPlayerInfos
    {
        /// <summary>
        /// Name of the player.
        /// </summary>
        string NickName { get; }
        /// <summary>
        /// Indicates whether or not the player's playing the turn.
        /// </summary>
        bool IsActivePlayer { get; }
        /// <summary>
        /// Avoids the player to play his cards. It also makes him choose the winning card of this turn.
        /// </summary>
        bool IsTurnMaster { get; }
        /// <summary>
        /// Indicates whether or not the player is online.
        /// </summary>
        bool IsOnline { get; }
        /// <summary>
        /// Player image.
        /// </summary>
        byte[] Avatar { get; }
        /// <summary>
        /// Number of games this player won per season.
        /// </summary>
        public Dictionary<int, int> GamesWon { get; }

    }
}
