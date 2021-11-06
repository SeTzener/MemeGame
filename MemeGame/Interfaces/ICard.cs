using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.Interfaces
{
    public interface ICard : ICardInfo
    {
        byte[] Image { get; set; }
        bool IsQuestion { get; set; }
        string Text { get; set; }
    }
}
