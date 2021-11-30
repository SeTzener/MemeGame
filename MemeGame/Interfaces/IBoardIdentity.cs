using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IBoardIdentity
    {
        /// <summary>
        /// Id of the board.
        /// </summary>
        int BoardId { get; }
    }
}
