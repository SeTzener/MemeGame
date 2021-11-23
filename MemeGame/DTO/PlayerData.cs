using MongoDB.Bson;

namespace MemeGame.DTO
{
    public class PlayerData
    {
        public ObjectId _id { get; set; }
        public string Nickname { get; set; }
    }
}