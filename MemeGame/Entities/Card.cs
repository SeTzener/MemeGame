using MemeGame.DTO;
using MemeGame.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Entities
{
    public class Card : ICard
    {
        public Card(CardData data)
        {
            this.Id = data._id;
            this.Text = data.Text;
            this.Infos = new CardInfos(data);
            string imagePath = String.Format("{0}/{1}{2}{3}", data.BucketName, data.S3Key, data.MemeName, data.Extension);
            GetImageFromStorage(imagePath);
        }

        public ICardInfos Infos { get; private set; }

        public byte[] Image { get; private set; }

        public string Text { get; private set; }

        public ObjectId Id { get; private set; }

        private void GetImageFromStorage(string imagePath)
        {

            // TODO: Implementare la funzionalità per recuperare l'immagine da S3
            this.Image = null;
        }
        
    }
}
