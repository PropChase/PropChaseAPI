using PropChase.Models;

namespace PropChase.Repository;
using MongoDB.Bson;

public interface IListingRepository
{
    Task<List<Listing>> GetListingsAsync(ObjectId id, int numListings);
    Task<User> GetUserByApiKeyAsync(string apiKey);
}