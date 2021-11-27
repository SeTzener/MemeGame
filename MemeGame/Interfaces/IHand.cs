using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IHand
    {
        List<ICard> Cards { get; }
        ICard DrawCard(int n);
        ICard DrawCard();
        ICard PlayCard();
        ICardInfos Discard(ICardIdentity id);
        ICardInfos Discard(List<ICardIdentity> ids);
        void PassTurn();
    }
}
