using MemeGame.DB.DTO;
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
        Tools tools;
        public DbOperations(bool isTest=false)
        {
            if (isTest)
            {
                dbName = "MemeGameTest";
                tools = new Tools(true);
            }
            else
                dbName = "MemeGame";

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
                tools.RelocateImage();
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
