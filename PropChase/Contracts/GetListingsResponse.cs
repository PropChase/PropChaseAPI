using System.Collections;
using PropChase.Models;

namespace PropChase.Contract.Listings;

public class GetListingsResponse
{
    public List<Listing> Listings { get; set; }

    public GetListingsResponse(List<Listing> listings)
    {
        Listings = listings;
    }
}