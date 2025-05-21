using BoardGamesQuizApi.Domain;
using BoardGamesQuizApi.Models;

namespace BoardGamesQuizApi.Services;

public class AuthService
{
    public LoginResponse Login(LoginRequest dto)
    {
        if (!UserName.TryParse(dto.Username, out var u) ||
            !Password.TryParse(dto.Password, out var p) ||
            !LoginValidator.IsValid(u!, p!))
            throw new UnauthorizedAccessException();

        return new LoginResponse { IsSuccess = true };
    }
}
