using MemeGame.Interfaces;
using MongoDB.Bson;
using System.Collections.Generic;

namespace MemeGame.DTO
{
    public class PlayerData
    {
        public ObjectId _id { get; set; }
        public string Nickname { get; set; }
        public string BucketName { get; set; }
        public string S3Key { get; set; }
        public decimal ImageSize { get; set; }
        public string Extension { get; set; }
        public List<IPlayerIdentity> FriendList { get; set; }
    }
}