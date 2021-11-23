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
        private string _dbName = "";
        MongoClient client;
        AwsS3 _storage;

        public DbOperations(bool isTest = false)
        {
            if (isTest)
            {
                _dbName = "MemeGameTest";
                _storage = new AwsS3(true);
            }
            else
            {
                _dbName = "MemeGame";
                _storage = new AwsS3();
            }

            client = new MongoClient(String.Format(Properties.Resources.MongoDB, _dbName));
        }

        #region CRUD
        public bool CreateCard()
        {
            try
            {
                Card card = PopulateNewCard();
                if (card != null)
                {
                    using (var session = client.StartSession())
                    {
                        var transactionOptions = new TransactionOptions(
                            readPreference: ReadPreference.Primary,
                            readConcern: ReadConcern.Local,
                            writeConcern: WriteConcern.WMajority);

                        var cancellationToken = CancellationToken.None; // normally a real token would be used
                        var result = session.WithTransaction(
                            (s, ct) =>
                            {
                                client.GetDatabase(_dbName).GetCollection<BsonDocument>("Cards").InsertOne(card.ToBsonDocument());
                                _storage.MoveToBucket(_storage.Folders.ToStore, card.S3Key, card.MemeName + card.Extension);

                                return "Card added to collection";
                            },
                            transactionOptions,
                            cancellationToken);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // TODO: inserire la logica in caso l'insert o lo spostamento del file non vadano a buon fine.
                return false;
            }
        }

        public bool DeleteCard(string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MemeName", name);
            try
            {
                client.GetDatabase(_dbName).GetCollection<BsonDocument>("Cards").DeleteOne(filter);
            }
            catch (Exception)
            {
                // TODO: Gestire l'errore.
                return false;
            }
            return true;
        }

        #endregion

        public List<Card> GetAllCards()
        {
            return client.GetDatabase(_dbName).GetCollection<Card>("Cards").Find(new BsonDocument()).ToList();
        }

        public Card FindCard(string cardName)
        {
            return client.GetDatabase(_dbName).GetCollection<Card>("Cards").Find(new BsonDocument()).ToList().Where(x => x.MemeName == cardName).FirstOrDefault();
        }

        public Card FindCard(ObjectId id)
        {
            return client.GetDatabase(_dbName).GetCollection<Card>("Cards").Find(new BsonDocument()).ToList().Where(x => x._id == id).FirstOrDefault();
        }

        public bool AddLoreText(ObjectId id, string loreText)
        {
            // TODO: Aggiungere storia del meme.

            return true;
        }


        private Card PopulateNewCard()
        {
            Card card = new Card();
            var s3Obj = _storage.GetS3ObjectInfo("ToStore");

            card.BucketName = s3Obj.BucketName;
            card.S3Key = _storage.Folders.StoredImages;
            card.ImageSize = Tools.GetKilobyteSize(s3Obj.Size);
            card.Extension = Path.GetExtension(s3Obj.Key);
            card.MemeName = s3Obj.Key.Substring(_storage.Folders.ToStore.Length).Replace(card.Extension, "");
            card.UploadDate = DateTime.Today;
            card.IsQuestion = false;

            return card;
        }
    }
}
