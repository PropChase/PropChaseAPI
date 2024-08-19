using PropChase.Models;
using PropChase.Services.Listings;
using ErrorOr;
using MongoDB.Bson;
using PropChase.Contract.Listings;
using PropChase.ServiceErrors;

namespace PropChase.Controllers;
using Microsoft.AspNetCore.Mvc;
using PropChase.Contracts.Listings;

public class ListingsController : ApiController
{
    private readonly IListingsService _listingsService;
    public ListingsController(IListingsService listingsService)
    {
        _listingsService = listingsService;
    }
    
    [HttpGet("{id}/{numListings:int}")]
    public async Task<IActionResult> GetListings([FromRoute] string id, [FromRoute] int numListings)
    {
        List<string> empty = new List<string>();
        empty.Add("000000000000000000000000");
        empty.Add("0");
        empty.Add("na");
        
        foreach (string item in empty)
        {
            if (id.Trim() == item)
            {
                id = "000000000000000000000000";
            }
        }
        
        if (!ObjectId.TryParse(id, out var objectId))
        {
            return Problem(new List<Error> { Errors.Listings.NotFound });
        }
        
        var getListingsRequest = ListingsRequest.Create(objectId, numListings);
        
        
        if (getListingsRequest.IsError)
        {
            return Problem(getListingsRequest.Errors);
        }
        
        var validRequest = getListingsRequest.Value;
        
        ErrorOr<List<Listing>> returnedVal = await _listingsService.GetListings(validRequest);

        return returnedVal.Match(
            listings => Ok(new GetListingsResponse(listings)),
            errors => Problem(errors)
        );
    }
}