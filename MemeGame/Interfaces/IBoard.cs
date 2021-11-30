using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IBoard : IBoardIdentity
    {
        /// <summary>
        /// Players of the game.
        /// </summary>
        List<IPlayer> Players { get; }
        /// <summary>
        /// Deck of Question cards.
        /// </summary>
        List<ICardIdentity> QuestionDeck { get; }
        /// <summary>
        /// Deck of Meme cards.
        /// </summary>
        List<ICardIdentity> MemeDeck { get; }
        /// <summary>
        /// Pile of cards played or discarded.
        /// </summary>
        List<ICardIdentity> DiscardPile { get; }
        /// <summary>
        /// Will retrieve a list of card ids from the selected bucket to form a deck.
        /// </summary>
        /// <param name="n">Number of cards to retrieve.</param>
        /// <param name="bucket">Name of the bucket to retrieve the cards in.</param>
        /// <returns></returns>
        List<ICardIdentity> AssembleDeck(int n, bool isQuestion);
    }
}
