using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeGame.DTO
{
    public class CardData
    {
        public ObjectId _id { get; set; }
        public string MemeName { get; set; }
        public bool IsQuestion { get; set; }
        public string Text { get; set; }
        public string BucketName { get; set; }
        public string S3Key { get; set; }
        public decimal ImageSize { get; set; }
        public string Extension { get; set; }
        public int MostUsed { get; set; }
        public string LoreText { get; set; }
    }
}
