using Microsoft.AspNetCore.Mvc;
using BoardGamesQuizApi.Models;
using BoardGamesQuizApi.Services;

namespace BoardGamesQuizApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _service;
    public AuthController(AuthService service) => _service = service;

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest dto)
    {
        try
        {
            var res = _service.Login(dto);       
            return Ok(res);
        }
        catch
        {
            return Unauthorized();
        }
    }
}
