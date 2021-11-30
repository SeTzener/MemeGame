using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface ICardInfos
    {
        /// <summary>
        /// Determines wheather or not the card is a Meme or a Question card.
        /// </summary>
        bool IsQuestion { get; }
        /// <summary>
        /// Card name.
        /// </summary>
        string CardName { get; }
        /// <summary>
        /// Size of the image expressed in kilobytes.
        /// </summary>
        decimal ImageSize { get; }
    }
}
