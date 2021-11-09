using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IPlayerInfos
    {
        string NickName { get; set; }
        bool IsActivePlayer { get; }
        bool IsTurnMaster { get; }
    }
}
