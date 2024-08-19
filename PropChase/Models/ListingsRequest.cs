using PropChase.ServiceErrors;

namespace PropChase.Models;
using ErrorOr;
using MongoDB.Bson;

public class ListingsRequest
{
    public ObjectId id { get; }
    public int numListings { get; }

    private ListingsRequest(ObjectId id, int numListings)
    {
        this.id = id;
        this.numListings = numListings;
    }

    public static ErrorOr<ListingsRequest> Create(ObjectId id, int numListings)
    {

        List<Error> errors = new();
        if (numListings < 0)
        {
            errors.Add(Errors.Listings.InvalidNumberOfListings);
        }

        if (errors.Count > 0)
        {
            return errors;
        }
        
        return new ListingsRequest(id, numListings);
    }
}
