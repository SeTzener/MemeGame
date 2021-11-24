using MemeGame.DB.DTO;
using MemeGame.Storage;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;

namespace MemeGame.DB
{
    public class DbOperations
    {
        MongoClient _client;
        AwsS3 _storage;

        public DbOperations(bool isTest = false)
        {
            string dbName = "";
            if (isTest)
            {
                dbName = "MemeGameTest";
                _storage = new AwsS3(true);
            }
            else
            {
                dbName = "MemeGame";
                _storage = new AwsS3();
            }

            _client = new MongoClient(String.Format(Properties.Resources.MongoDB, dbName));
            this.Cards = new CardOperations(dbName, _client, _storage);
        }

        public CardOperations Cards { get; set; }
    }
}
