using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PropChase.Models;


public class User
{
    [BsonId]
    public ObjectId Id { get; set; }
        
    [BsonElement("fName")]
    public string FName { get; set; }
        
    [BsonElement("Name")]
    public string Name { get; set; }
        
    [BsonElement("email")]
    public string Email { get; set; }
        
    [BsonElement("phoneNumber")]
    public string PhoneNumber { get; set; }

    [BsonElement("apiKey")] 
    public string ApiKey { get; set; }

    public User(ObjectId id, string fName, string name, string email, string phoneNumber, string apiKey)
    {
        Id = id;
        FName = fName;
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        ApiKey = apiKey;
    }
}