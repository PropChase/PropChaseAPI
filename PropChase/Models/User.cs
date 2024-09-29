using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PropChase.Models;


public class User
{
    [BsonId]
    public ObjectId Id { get; set; }
        
    [BsonElement("name")]
    public string Name { get; set; }
        
    [BsonElement("email")]
    public string Email { get; set; }
    
    [BsonElement("password")]
    public string Password { get; set; }
    
    [BsonElement("apiKey")] 
    public string ApiKey { get; set; }
    
    [BsonElement("status")] 
    public bool Status { get; set; }

    public User(ObjectId id, string name, string email, string password, string apiKey)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        ApiKey = apiKey;
        Status = false;
    }
}