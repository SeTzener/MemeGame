using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IPlayer : IPlayerInfos, IPlayerIdentity
    {
        IHand Hand { get; }
        int Points { get; }
        void MakeYourChoice();
    }
}
