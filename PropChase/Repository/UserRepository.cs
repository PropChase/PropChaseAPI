using MongoDB.Driver;
using PropChase.DataLayer;
using PropChase.Models;

namespace PropChase.Repository;

public class UserRepository : IUserRepository
{
    private readonly MongoDbContext _context;

    public UserRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task CreateUserAsync(User user)
    {
        await _context.Users.InsertOneAsync(user);
    }

    public async Task<User?> GetUserByCredentialsAsync(string name, string email, string password)
    {
        // Query MongoDB to check if a user with the same name, email, and password exists
        var filter = Builders<User>.Filter.And(
            Builders<User>.Filter.Eq(u => u.Name, name),
            Builders<User>.Filter.Eq(u => u.Email, email),
            Builders<User>.Filter.Eq(u => u.Password, password)
        );

        var user = await _context.Users.Find(filter).FirstOrDefaultAsync();
        return user;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users.Find(user => user.Email == email).FirstOrDefaultAsync();
    }
}