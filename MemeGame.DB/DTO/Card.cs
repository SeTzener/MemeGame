using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.DB.DTO
{
    public class Card : CardIdentity
    {
        public string MemeName { get; set; }
        public bool IsQuestion { get; set; }
        public string Text { get; set; }
        public string BucketName { get; set; }
        public string S3Key { get; set; }
        public decimal ImageSize { get; set; }
        public string Extension { get; set; }
        public int MostUsed { get; set; }
        public string LoreText { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
