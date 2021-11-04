using MemeGame.DB.DTO;
using MemeGame.Storage;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MemeGame.DB
{
    public class DbOperations
    {
        private string _dbName = "";
        MongoClient client;
        AwsS3 _storage;

        public DbOperations(bool isTest=false)
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

        public List<Card> GetCards()
        {
            return client.GetDatabase(_dbName).GetCollection<Card>("Cards").Find(new BsonDocument()).ToList();
        }

        public bool AddLoreText(ObjectId id, string loreText)
        {
            // TODO: Aggiungere storia del meme.

            return true;
        }

        public bool CreateCard()
        {
            try
            {
                Card card = PopulateNewCard();
                using (var session = client.StartSession())
                {
                    // Step 2: Optional. Define options to use for the transaction.
                    var transactionOptions = new TransactionOptions(
                        readPreference: ReadPreference.Primary,
                        readConcern: ReadConcern.Local,
                        writeConcern: WriteConcern.WMajority);
                    // Step 3: Define the sequence of operations to perform inside the transactions
                    var cancellationToken = CancellationToken.None; // normally a real token would be used
                    var result = session.WithTransaction(
                        (s, ct) =>
                        {
                            client.GetDatabase(_dbName).GetCollection<BsonDocument>("Cards").InsertOne(card.ToBsonDocument());
                            _storage.MovetoConserved(card.BucketName, card.S3Key).GetAwaiter();

                            return "Card added to collection";
                        },
                        transactionOptions,
                        cancellationToken);
                }

                // TODO: Spostare il file su AWS da "DaCaricare\" alla cartella di destinazione.
            }
            catch(Exception ex)
            {
                // TODO: inserire la logica in caso l'insert o lo spostamento del file non vadano a buon fine.
                return false;
            }

            return true;
        }

        private Card PopulateNewCard()
        {
            Card card = new Card();
            var s3Obj = _storage.GetS3ObjectInfo();
            string s3Key = s3Obj.Key.Substring(0, s3Obj.Key.IndexOf('/') + 1);

            card.BucketName = s3Obj.BucketName;
            card.S3Key = _storage.SelectDestinationBucket(s3Key);
            card.ImageSize = Tools.GetKilobyteSize(s3Obj.Size);
            card.Extension = Path.GetExtension(s3Obj.Key);
            card.MemeName = s3Obj.Key.Substring(s3Key.Length).Replace(card.Extension, "");
            card.UploadDate = DateTime.Today;
            card.IsQuestion = false;

            return card;
        }
    }
}
