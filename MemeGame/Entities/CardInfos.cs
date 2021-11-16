using MemeGame.DTO;
using MemeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.Entities
{
    public class CardInfos : ICardInfos
    {
        public CardInfos(CardData data)
        {
            this.IsQuestion = data.IsQuestion;
            this.MemeName = data.MemeName;
            this.ImageSize = data.ImageSize;
            this.BucketPath = GetBucketPath(data);
        }
        public bool IsQuestion { get; private set; }

        public string MemeName { get; private set; }

        public decimal ImageSize { get; private set; }

        internal string BucketPath { get; private set; }

        private string GetBucketPath(CardData data)
        {
            return String.Format("{0}/{1}/{2}.{3}", data.BucketName, data.S3Key, data.MemeName, data.Extension);
        }
    }
}
