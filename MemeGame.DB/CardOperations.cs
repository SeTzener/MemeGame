using MemeGame.DB.DTO;
using MemeGame.Storage;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace MemeGame.DB
{
    public class CardOperations : ICrud<Card>
    {
        private MongoClient _client { get; set; }
        private AwsS3 _storage { get; set; }
        private string _dbName { get; set; }
        public CardOperations(string dbName, MongoClient client, AwsS3 storage)
        {
            this._dbName = dbName;
            this._client = client;
            this._storage = storage;
        }

        #region CRUD
        public bool Create()
        {
            try
            {
                Card card = PopulateNewCard();
                if (card != null)
                {
                    using (var session = _client.StartSession())
                    {
                        var transactionOptions = new TransactionOptions(
                            readPreference: ReadPreference.Primary,
                            readConcern: ReadConcern.Local,
                            writeConcern: WriteConcern.WMajority);

                        var cancellationToken = CancellationToken.None; // normally a real token would be used
                        var result = session.WithTransaction(
                            (s, ct) =>
                            {
                                _client.GetDatabase(_dbName).GetCollection<BsonDocument>("Cards").InsertOne(card.ToBsonDocument());
                                _storage.MoveToBucket(_storage.Folders.ToStore, card.S3Key, card.MemeName + card.Extension);

                                return "Card added to collection";
                            },
                            transactionOptions,
                            cancellationToken);
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                // TODO: inserire la logica in caso l'insert o lo spostamento del file non vadano a buon fine.
                return false;
            }
        }
        public Card Find(string cardName)
        {
            return _client.GetDatabase(_dbName).GetCollection<Card>("Cards").Find(new BsonDocument()).ToList().Where(x => x.MemeName == cardName).FirstOrDefault();
        }
        public Card Find(ObjectId id)
        {
            return _client.GetDatabase(_dbName).GetCollection<Card>("Cards").Find(new BsonDocument()).ToList().Where(x => x._id == id).FirstOrDefault();
        }
        public Card Update(string name)
        {
            throw new NotImplementedException();
        }
        public Card Update(ObjectId id)
        {
            throw new NotImplementedException();
        }
        public bool Delete(string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MemeName", name);
            try
            {
                _client.GetDatabase(_dbName).GetCollection<BsonDocument>("Cards").DeleteOne(filter);
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
            return _client.GetDatabase(_dbName).GetCollection<Card>("Cards").Find(new BsonDocument()).ToList();
        }


        public bool AddLoreText(ObjectId id, string loreText)
        {
            // TODO: Aggiungere storia del meme.

            return true;
        }

        public List<ObjectId> GetRandomCards(bool isQuestion)
        {
            Random rnd = new Random();

            return _client.GetDatabase(_dbName).GetCollection<Card>("Cards").Find(new BsonDocument()).ToList().Where(x => x.IsQuestion == isQuestion).Select(x=>x._id).OrderBy(x => rnd.Next()).Take(1).ToList();
        }
        public List<ObjectId> GetRandomCards(int num, bool isQuestion)
        {
            Random rnd = new Random();

            return _client.GetDatabase(_dbName).GetCollection<Card>("Cards").Find(new BsonDocument()).ToList().Where(x => x.IsQuestion == isQuestion).Select(x=>x._id).OrderBy(x => rnd.Next()).Take(num).ToList();
           
        }
        private Card PopulateNewCard()
        {
            Card card = new Card();
            var s3Obj = _storage.GetS3ObjectInfo(_storage.Folders.ToStore);
            if (s3Obj != null)
            {
                card.BucketName = s3Obj.BucketName;
                card.S3Key = _storage.Folders.StoredImages;
                card.ImageSize = Tools.GetKilobyteSize(s3Obj.Size);
                card.Extension = Path.GetExtension(s3Obj.Key);
                card.MemeName = s3Obj.Key.Substring(_storage.Folders.ToStore.Length).Replace(card.Extension, "");
                card.UploadDate = DateTime.Today;
                card.IsQuestion = false;
                
                return card;
            }
            else
                return null;
        }

    }
}
