namespace PropChase.Services.User;

using Models;
using ErrorOr;

public interface IUserService
{
    Task<ErrorOr<User>> CreateUser(string name, string email, string password);

}