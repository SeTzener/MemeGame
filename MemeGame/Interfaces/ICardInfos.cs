using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface ICardInfos
    {
        bool IsQuestion { get; }
        string MemeName { get; }
        decimal ImageSize { get; }
    }
}
