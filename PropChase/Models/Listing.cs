using MongoDB.Bson.Serialization.Attributes;

namespace PropChase.Models;
using MongoDB.Bson;


public class Listing
{
    [BsonId]
    public ObjectId Id { get; set; }
        
    [BsonElement("Type")]
    public string Type { get; set; }
        
    [BsonElement("site")]
    public string Site { get; set; }
        
    [BsonElement("sqft")]
    public double Sqft { get; set; }
        
    [BsonElement("address")]
    public string Address { get; set; }
        
    [BsonElement("url")]
    public string Url { get; set; }
        
    [BsonElement("numBedrooms")]
    public int NumBedrooms { get; set; }
        
    [BsonElement("numBathrooms")]
    public int NumBathrooms { get; set; }
        
    [BsonElement("price")]
    public double Price { get; set; }
        
    [BsonElement("rawListing")]
    public string RawListing { get; set; }

    public Listing(ObjectId id, string type, string site, double sqft, string address, string url, int numBedrooms, 
        int numBathrooms, double price, string rawListing)
    {
        Id = id;
        Type = type;
        Site = site;
        Sqft = sqft;
        Address = address;
        Url = url;
        NumBedrooms = numBedrooms;
        NumBathrooms = numBathrooms;
        Price = price;
        RawListing = rawListing;
    }
}