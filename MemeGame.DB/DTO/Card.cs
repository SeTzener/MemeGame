using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.DB.DTO
{
    public class Card
    {
        public ObjectId _id { get; set; }
        public bool IsQuestion { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public int ImageSize { get; set; }
        public int MostUsed { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
