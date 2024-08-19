namespace PropChase.Contracts.Listings;
using MongoDB.Bson;

public record GetListingsRequest(
    ObjectId id,
    int numListings
    );
    
    
    
    
    
    