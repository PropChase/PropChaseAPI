using System.Collections;
using PropChase.Models;
using ErrorOr;
using PropChase.Repository;
using PropChase.ServiceErrors;

namespace PropChase.Services.Listings;

public class ListingsService : IListingsService
{
    private readonly IListingRepository _listingRepository;

    public ListingsService(IListingRepository listingRepository)
    {
        _listingRepository = listingRepository;
    }

    public async Task<ErrorOr<List<Listing>>> GetListings(ListingsRequest request)
    {
        var listings = await _listingRepository.GetListingsAsync(request.id, request.numListings);

        if (!listings.Any())
        {
            return Errors.Listings.NotFound; 
        }

        return listings; 
    }
}