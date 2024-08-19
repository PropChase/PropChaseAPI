using PropChase.Models;

namespace PropChase.DataLayer;
using MongoDB.Driver;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext()
    {
        var connectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("MongoDB connection string environment variable not found.");
        }

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("Listings");
    }

    public IMongoCollection<Listing> Listings => _database.GetCollection<Listing>("Listings");
    public IMongoCollection<User> Users => _database.GetCollection<User>("Users"); 
}