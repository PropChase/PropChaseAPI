using PropChase.Models;

namespace PropChase.Repository;

public interface IUserRepository
{
    Task CreateUserAsync(User user);
    Task<User> GetUserByEmailAsync(string email);
}