using MongoDB.Driver;
using PropChase.DataLayer;
using MongoDB.Bson;
using PropChase.Models;

namespace PropChase.Repository;


public class ListingRepository : IListingRepository
{
    private readonly MongoDbContext _context;

    public ListingRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task<List<Listing>> GetListingsAsync(ObjectId id, int numListings)
    {
        var idIsEmpty = false;
        if (id.ToString().Trim() == "000000000000000000000000")
        {
            idIsEmpty = true;
        }
        
        
        // Implement query to fetch listings based on id and numListings
        if (idIsEmpty && numListings > 0)
        {
            return await _context.Listings
                .Find(_ => true)
                .Limit(numListings)
                .ToListAsync();
        }
        
        if(idIsEmpty && numListings <= 0)
        {
            return await _context.Listings
                .Find(_ => true)
                .ToListAsync();
        }
        
        if (!idIsEmpty && numListings <= 0)
        {
            return await _context.Listings
                .Find(listing => listing.Id == id)
                .ToListAsync();
        }
        
        if (!idIsEmpty && numListings > 0)
        {
            var listings = await _context.Listings
                .Find(_ => true)
                .Sort(Builders<Listing>.Sort.Ascending(l => l.Id))
                .ToListAsync();

            var index = listings.FindIndex(l => l.Id == id);

            if (index >= 0)
            {
                return listings.Skip(index).Take(numListings).ToList();
            }
        }
        return new List<Listing>();
    }
    public async Task<User> GetUserByApiKeyAsync(string apiKey)
    {
        return await _context.Users
            .Find(user => user.ApiKey == apiKey)
            .FirstOrDefaultAsync();
    }
}