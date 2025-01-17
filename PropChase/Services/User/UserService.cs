using PropChase.Models;
using MongoDB.Bson;
using PropChase.Repository;
using ErrorOr;
using System.Security.Cryptography;
using PropChase.ServiceErrors;

namespace PropChase.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Models.User>> CreateUser(string name, string email, string password)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(email);

        if (existingUser != null)
        {
            return Errors.Users.DuplicateEmail;
        }
        
        var apiKey = GenerateApiKey();

        var user = new Models.User(ObjectId.GenerateNewId(), name, email, password, apiKey);
        await _userRepository.CreateUserAsync(user);

        return user;
    }
    public async Task<ErrorOr<Models.User>> CheckIfUserExistsAsync(string name, string email, string password)
    {
        var user = await _userRepository.GetUserByCredentialsAsync(name, email, password);

        if (user is null)
        {
            return Errors.Users.NotFound; 
        }

        return user;
    }
    
    public async Task<ErrorOr<Models.User>> RecreditUser(string name, string email, string password)
    {
        var user = await _userRepository.GetUserAndChangeKey(name, email, password);

        if (user is null)
        {
            return Errors.Users.NotFound; 
        }
        
        if (user.Name == "dead" && user.Email == "dead" && user.Password == "dead" && user.ApiKey == "dead")
        {
            return Errors.Users.NotSubscribed;
        }

        return user;
    }

    private string GenerateApiKey()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }
}