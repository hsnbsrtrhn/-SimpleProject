using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;


namespace CryptoListApi.MongoDb
{
    public class MongoDBService
    {
        private readonly IMongoCollection<CryptoData> _collection;

        public MongoDBService(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<CryptoData>(settings.Value.CollectionName);
        }

        public CryptoData GetDataFromMongoDB(string id)
        {
            return _collection.Find(data => data.Id == id).FirstOrDefault();
        }

        public void AddDataToMongoDB(CryptoData data)
        {
            _collection.InsertOne(data);
        }



       
    }
}
