using WebApp.Strategy.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebApp.Strategy.Repositories
{
    public class ProductRepositoryFromMongoDb:IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductRepositoryFromMongoDb(IConfiguration configuration)
        {
            var connnectionString = configuration.GetConnectionString("MongoDb");
            

            var client = new MongoClient(connnectionString);

            var database = client.GetDatabase("ProductDb");

            _productCollection = database.GetCollection<Product>("Products");
        }

        public async Task Delete(Product product)
        {
            await _productCollection.DeleteOneAsync(x => x.Id == product.Id);
        }

        public async Task<List<Product>> GetAllByUserId(string userId)
        {
            return await _productCollection.Find(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Product> GetById(string id)
        {
            return await _productCollection.Find(x => x.UserId == id).FirstOrDefaultAsync();
        }

        public async Task<Product> Save(Product product)
        {
            await _productCollection.InsertOneAsync(product);

            return product;
        }

        public async Task Update(Product product)
        {
            await _productCollection.FindOneAndReplaceAsync(x => x.Id == product.Id, product);
        }
    }
}