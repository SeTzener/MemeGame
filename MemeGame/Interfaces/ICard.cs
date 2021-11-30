using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.Interfaces
{
    public interface ICard : ICardIdentity
    {
        /// <summary>
        /// Card informations.
        /// </summary>
        ICardInfos Infos { get; }
        /// <summary>
        /// Card Image.
        /// </summary>
        byte[] Image { get; }
        /// <summary>
        /// Text to overlay on the card.
        /// </summary>
        string Text { get; }
    }
}
