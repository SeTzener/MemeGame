using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.Interfaces
{
    public interface ICard : ICardIdentity
    {
        ICardInfos Infos { get; }
        byte[] Image { get; }
        string Text { get; }
    }
}
