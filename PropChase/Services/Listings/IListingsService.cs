using System.Collections;
using PropChase.Models;
using ErrorOr;

namespace PropChase.Services.Listings;

public interface IListingsService
{
    Task<ErrorOr<List<Listing>>> GetListings(ListingsRequest request);
}