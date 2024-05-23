using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using WebInvManagement.Models;

namespace WebInvManagement.Pages
{
public class MongoDBService
{
    private readonly IMongoDatabase _database;

    public MongoDBService(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("MongoDBConnection");
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("productInventory");
    }

    // Example method to access a MongoDB collection
    public IMongoCollection<Product> GetCollection<Product>(string collectionName)
    {
        return _database.GetCollection<Product>(collectionName);
    }

    public async Task InsertProductAsync(Product product, string collectionName)
    {
        var collection = _database.GetCollection<Product>(collectionName);
        await collection.InsertOneAsync(product);
    }

        // Example method to delete a document from a collection based on a filter
    public async Task DeleteProductAsync(FilterDefinition<Product> filter, string collectionName)
    {
        var collection = _database.GetCollection<Product>(collectionName);
        await collection.DeleteOneAsync(filter);
    }

}
}