using MemeGame.DTO;
using MemeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Entities
{
    public class Rules : IRules
    {
        public int MemeDeck { get; private set; }
        public int QuestionDeck { get; private set; }
        public int CardInHand { get; private set; }

        public Rules(RulesData data)
        {

        }
    }
}
