using MemeGame.DTO;
using MemeGame.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Entities
{
    public class Player : IPlayer
    {
        public Player(PlayerData data)
        {
            this.PlayerId = data._id;
            this.NickName = data.Nickname;
            this.Hand = new Hand();
            this.Points = 0;
        }
        public IHand Hand { get; private set; }

        public ObjectId PlayerId { get; private set; }
        public int Points { get; private set; }
        public string NickName { get; private set; }
        public bool IsOnline { get; private set; }
        public bool IsActivePlayer { get; private set; }
        public bool IsTurnMaster { get; private set; }
        public byte[] Avatar { get; private set; }
        public Dictionary<int, int> GamesWon { get; private set; } // TODO: Add logic to retrieve data from the DTO PlayerSeasonData


        public void MakeYourChoice(ICardIdentity id)
        {
            throw new NotImplementedException();
        }
    }
}
