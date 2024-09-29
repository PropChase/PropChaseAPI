using Microsoft.AspNetCore.Mvc;
using PropChase.Contracts;
using PropChase.Services.User;

namespace PropChase.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
    {
        var createUserResult = await _userService.CreateUser(request.Name, request.Email, request.Password);

        return createUserResult.Match(
            user => Ok(new { user.Id, user.ApiKey }),
            errors => Problem(title: errors.First().Description)
        );
    }
}