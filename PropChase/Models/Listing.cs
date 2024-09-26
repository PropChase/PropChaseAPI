using MongoDB.Bson.Serialization.Attributes;

namespace PropChase.Models;
using MongoDB.Bson;


public class Listing
{
    [BsonId]
    public ObjectId Id { get; set; }
        
    [BsonElement("Type")]
    public string Type { get; set; }
        
    [BsonElement("Site")]
    public string Site { get; set; }
        
    [BsonElement("Sqft")]
    public double Sqft { get; set; }
        
    [BsonElement("Address")]
    public string Address { get; set; }
        
    [BsonElement("Url")]
    public string Url { get; set; }
        
    [BsonElement("NumBedrooms")]
    public int NumBedrooms { get; set; }
        
    [BsonElement("NumBathrooms")]
    public int NumBathrooms { get; set; }
        
    [BsonElement("Price")]
    public double Price { get; set; }
        
    [BsonElement("RawListing")]
    public string RawListing { get; set; }
    
    [BsonElement("NumRooms")]
    public double NumRooms { get; set; }
    
    [BsonElement("Score")]
    public Int32 Score { get; set; }
    
    [BsonElement("Neighbourhood")]
    public string Neighbourhood { get; set; }
    
    [BsonElement("Latitude")]
    public double? Latitude { get; set; }
    
    [BsonElement("Longitude")]
    public double? Longitude { get; set; }

    public Listing(ObjectId id, string type, string site, double sqft, string address, string url, int numBedrooms, 
        int numBathrooms, double price, string rawListing, double numRooms, Int32 score)
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
        NumRooms = numRooms;
        Score = score;
    }
}