using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IPlayer : IPlayerInfos, IPlayerIdentities
    {
        IHand Hand { get; set; }
        int Points { get; set; }
    }
}
