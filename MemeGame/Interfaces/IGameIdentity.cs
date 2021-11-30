using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IGameIdentity
    {
        /// <summary>
        /// Id of the game.
        /// </summary>
        int GameId { get; }
    }
}
