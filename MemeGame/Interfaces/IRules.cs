using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IRules
    {
        /// <summary>
        /// Number of cards in meme deck.
        /// </summary>
        public int MemeDeck { get; set; }
        /// <summary>
        /// Number of cards in question deck.
        /// </summary>
        public int QuestionDeck { get; set; }
        /// <summary>
        /// Number of cards in hand.
        /// </summary>
        public int CardInHand { get; set; }

    }
}
