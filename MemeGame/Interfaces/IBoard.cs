using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IBoard : IBoardIdentities
    {
        List<IPlayer> Players { get; }
        List<ICardInfos> DiscardPile { get; }
    }
}
