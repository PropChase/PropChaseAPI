namespace PropChase.Contracts;

public record CheckUserRequest(
    string Name,
    string Email,
    string Password
);