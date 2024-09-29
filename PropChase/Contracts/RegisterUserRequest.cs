namespace PropChase.Contracts;

public record RegisterUserRequest(
    string Name,
    string Email,
    string Password
);