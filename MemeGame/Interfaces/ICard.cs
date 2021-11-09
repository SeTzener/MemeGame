using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.Interfaces
{
    public interface ICard : ICardInfos, ICardIdentities
    {
        byte[] Image { get; }
        string Text { get; }
    }
}
