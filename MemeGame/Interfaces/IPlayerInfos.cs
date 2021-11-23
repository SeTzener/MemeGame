using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IPlayerInfos
    {
        string NickName { get; }
        bool IsActivePlayer { get; }
        bool IsTurnMaster { get; }
    }
}
