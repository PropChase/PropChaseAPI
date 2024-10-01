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
    
    [HttpPost("exists")]
    public async Task<IActionResult> CheckUser([FromBody] CheckUserRequest request)
    {
        var userResult = await _userService.CheckIfUserExistsAsync(request.Name, request.Email, request.Password);

        return userResult.Match(
            user => Ok(new { user.Id, user.ApiKey }),
            errors => Problem(title: errors.First().Description)
        );
    }
    
    [HttpPost("recredit")]
    public async Task<IActionResult> RecreditUser([FromBody] CheckUserRequest request)
    {
        var userResult = await _userService.RecreditUser(request.Name, request.Email, request.Password);

        return userResult.Match(
            user => Ok(new { user.Id, user.ApiKey }),
            errors => Problem(title: errors.First().Description)
        );
    }

}