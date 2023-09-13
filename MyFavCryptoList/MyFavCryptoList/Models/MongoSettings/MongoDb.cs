/*

using MongoDB.Bson;
using MongoDB.Driver;

namespace CryptoListApi.Models.MongoSettings
{
    public class MongoDb
    {

        public string ConnectionURI { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string CollectionName { get; set; } = null;

        static void Main(string[] args)
        {


            var dbClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = dbClient.GetDatabase("mydatabse");
            var collection = database.GetCollection<BsonDocument>("CollectionName");



        }
    }
}
*/