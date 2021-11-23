using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IBoard : IBoardIdentity
    {
        List<IPlayer> Players { get; }
        List<ICardIdentity> QuestionDeck { get; }
        List<ICardIdentity> MemeDeck { get; }
        List<ICardIdentity> DiscardPile { get; }
        IPlayground Playground { get; }
        decimal Timer { get; }
        decimal TimeCount();
        /// <summary>
        /// Will retrieve a list of card ids from the selected bucket to form a deck.
        /// </summary>
        /// <param name="n">Number of cards to retrieve.</param>
        /// <param name="bucket">Name of the bucket to retrieve the cards in.</param>
        /// <returns></returns>
        List<ICardIdentity> AssembleDeck(int n, bool isQuestion);
    }
}
