using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CryptoListApi.MongoDb
{
    public class CryptoData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Pair")]
        public string Pair { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }
    }
}
