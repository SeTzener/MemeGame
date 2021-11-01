using MemeGame.DB.DTO;
using MemeGame.Storage;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MemeGame.DB
{
    public class DbOperations
    {
        string dbName = "";
        MongoClient client;
        AwsS3 _storage;

        public DbOperations(bool isTest=false)
        {
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

            client = new MongoClient(Properties.Resources.MongoDB);

        }

        public List<Card> GetCards()
        {
            return client.GetDatabase("CornettiBot").GetCollection<Card>("Cards").Find(new BsonDocument()).ToList();
        }

        public bool CreateCard(Card card)
        {
            try
            {
                _storage.GetS3ObjectToStore();
                client.GetDatabase(dbName).GetCollection<BsonDocument>("Cards").InsertOne(card.ToBsonDocument());

                // TODO: Spostare il file su AWS da "DaCaricare\" alla cartella di destinazione.
            }
            catch(Exception ex)
            {
                // TODO: inserire la logica in caso l'insert o lo spostamento del file non vadano a buon fine.
                return false;
            }

            return true;
        }
    }
}
