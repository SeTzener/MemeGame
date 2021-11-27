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
        }
        public IHand Hand { get; private set; }

        public int Points { get; private set; }

        public string NickName { get; private set; }

        public bool IsActivePlayer { get; private set; }

        public bool IsTurnMaster { get; private set; }

        public ObjectId PlayerId { get; private set; }

        public void MakeYourChoice(ICardIdentity id)
        {
            throw new NotImplementedException();
        }
    }
}
