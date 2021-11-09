using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IBoard : IBoardIdentity
    {
        List<IPlayer> Players { get; }
        List<ICardIdentity> Deck { get; }
        List<ICardInfos> DiscardPile { get; }
        IPlayArea PlayArea { get; }
        decimal Timer { get; }
        decimal TimeCount();
    }
}
