using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using CryptoListApi.MongoDb;
using CryptoListApi.Models.Requests;

namespace CryptoListApi.Controllers
{
    [Route("api/crypto-data")]
    [ApiController]
    public class CryptoDataController : ControllerBase
    {
        private readonly IMongoCollection<CryptoData> _collection;

        public CryptoDataController(IMongoDatabase database)
        {
            _collection = database.GetCollection<CryptoData>("cryptoData");
        }

        [HttpGet]
        public IActionResult GetCryptoData()
        {
            List<CryptoData> cryptoDataList = _collection.Find(_ => true).ToList();
            return Ok(cryptoDataList);
        }

        [HttpPost]
        public IActionResult CreateCryptoData([FromBody] CreateCryptoRequest request)
        {
            if (request == null)
            {
                return BadRequest("Geçersiz istek verisi.");
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                return BadRequest("Name alanı gereklidir.");
            }

            
            var newCryptoData = new CryptoData
            {
                Pair = request.Name
               
            };

           
            _collection.InsertOne(newCryptoData);

            return Ok("CryptoData başarıyla eklendi.");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCryptoData(string id, [FromBody] CryptoData updatedData)
        {
            var filter = Builders<CryptoData>.Filter.Eq("_id", id);
            var update = Builders<CryptoData>.Update
                .Set("Pair", updatedData.Pair)
                .Set("Price", updatedData.Price);

            var result = _collection.UpdateOne(filter, update);

            if (result.ModifiedCount == 0)
            {
                return NotFound("Böyle bir CryptoData bulunamadı.");
            }

            return Ok("CryptoData güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCryptoData(string id)
        {
            var filter = Builders<CryptoData>.Filter.Eq("_id", id);
            var result = _collection.DeleteOne(filter);

            if (result.DeletedCount == 0)
            {
                return NotFound("Böyle bir CryptoData bulunamadı.");
            }

            return Ok("CryptoData başarıyla silindi.");
        }
    }
}
