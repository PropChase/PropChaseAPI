using System.Runtime.InteropServices.JavaScript;
using ErrorOr;

namespace PropChase.ServiceErrors;

public static class Errors
{
    public static class Listings
    {
        public static Error InvalidNumberOfListings => Error.Validation(
            "Number of listings must be and integer that is >= 0",
            "Listing not found"
            );
        public static Error NotFound => Error.NotFound(
            "Listings not found",
            "Listing not found"
        );
    }
}