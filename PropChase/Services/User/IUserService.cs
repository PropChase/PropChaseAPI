namespace PropChase.Services.User;

using Models;
using ErrorOr;

public interface IUserService
{
    Task<ErrorOr<User>> CreateUser(string name, string email, string password);
    Task<ErrorOr<User>> CheckIfUserExistsAsync(string name, string email, string password);
    Task<ErrorOr<User>> RecreditUser(string name, string email, string password);

}