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
        public int MemeDeck { get; }
        /// <summary>
        /// Number of cards in question deck.
        /// </summary>
        public int QuestionDeck { get; }
        /// <summary>
        /// Number of cards in hand.
        /// </summary>
        public int CardInHand { get; }
        /// <summary>
        /// Game duration expressed in seconds
        /// </summary>
        public int GameDuration { get; }
        /// <summary>
        /// Turn duration expressed in seconds.
        /// </summary>
        public int TurnDuration { get; }


    }
}
