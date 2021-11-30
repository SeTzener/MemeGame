using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Interfaces
{
    public interface IHand
    {
        /// <summary>
        /// Cards in hand.
        /// </summary>
        List<ICard> Cards { get; }
        /// <summary>
        /// Draw a card to add to the hand.
        /// </summary>
        /// <returns></returns>
        ICard DrawCard();
        /// <summary>
        /// Draw cards to add to the hand.
        /// </summary>
        /// <param name="n">Number of cards to draw.</param>
        /// <returns></returns>
        ICard DrawCard(int n);
        /// <summary>
        /// Play the chosen card.
        /// </summary>
        /// <param name="id">Id of the card to play.</param>
        /// <returns></returns>
        ICard PlayCard(ICardIdentity id);
        /// <summary>
        /// Discard the choosen card.
        /// </summary>
        /// <param name="id">Id of the card to discard.</param>
        /// <returns></returns>
        ICardInfos Discard(ICardIdentity id);
        /// <summary>
        /// Discard the choosen cards.
        /// </summary>
        /// <param name="ids">Ids of the cards to discard.</param>
        /// <returns></returns>
        ICardInfos Discard(List<ICardIdentity> ids);
        /// <summary>
        /// Pass the turn to the next player.
        /// </summary>
        void PassTurn();
    }
}
