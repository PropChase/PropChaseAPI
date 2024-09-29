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

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users.Find(user => user.Email == email).FirstOrDefaultAsync();
    }
}