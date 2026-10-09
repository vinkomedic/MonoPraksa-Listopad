using Microsoft.AspNetCore.Mvc;
using MoviesTVShows.DTOs;
using MoviesTVShows.Service.Common;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MoviesTVShows.Model;

namespace MoviesTVShows.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IConfiguration _configuration;

    public AuthController(IAuthService authService, IConfiguration configuration)
    {
        _authService = authService;
        _configuration = configuration;
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Role, user.Role)
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

        var credentials = new SigningCredentials( key,SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddHours(1), signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest input)
    {
        bool registered =await _authService.RegisterAsync(input.Email, input.Password);

        if (!registered)
        {
            return Conflict("User with that email already exists.");
        }

        return Created("", new{input.Email, Role = "User" });
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest input)
    {
        var user = await _authService.LoginAsync(input.Email,input.Password);

        if (user == null)
        {
            return Unauthorized("Invalid email or password.");
        }

        string token = CreateToken(user);

        return Ok(new{token, email = user.Email, role = user.Role});
    }
}