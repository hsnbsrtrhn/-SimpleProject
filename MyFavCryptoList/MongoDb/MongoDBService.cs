using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

using MongoDB.Driver;

public interface IMongoDbContext
{
    IMongoDatabase Database { get; }
    IMongoCollection<T> GetCollection<T>(string name);
}



public class MongoDBService<T>
{
    private readonly IMongoCollection<T> _collection;

    public MongoDBService(IMongoDbContext dbContext, string collectionName)
    {
        _collection = dbContext.GetCollection<T>(collectionName);
    }

    // Veri Ekleme
    public void InsertData(T data)
    {
        _collection.InsertOne(data);
    }

    // Tüm Verileri Getirme
    public List<T> GetAllData()
    {
        return _collection.Find(x => true).ToList();
    }

    // Belirli Bir Veriyi Getirme
    public T GetDataById(string id)
    {
        return _collection.Find(x => x.Id == id).FirstOrDefault();
    }

    // Veri Güncelleme
    public void UpdateData(string id, T data)
    {
        _collection.ReplaceOne(x => x.Id == id, data);
    }

    // Veri Silme
    public void DeleteData(string id)
    {
        _collection.DeleteOne(x => x.Id == id);
    }
}
