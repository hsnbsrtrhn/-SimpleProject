/* 
 * using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace CryptoListApi.Models.MongoSettings
{
    public class MongoCryptoPair
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Pair { get; set; }
        public decimal Price { get; set; }
    }
}
*/