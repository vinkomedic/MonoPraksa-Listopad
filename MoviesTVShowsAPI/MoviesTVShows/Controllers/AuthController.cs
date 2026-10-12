using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoviesTVShows.DTOs;
using MoviesTVShows.Model;
using MoviesTVShows.Service;
using MoviesTVShows.Service.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesTVShows.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
     private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest input)
    {
        bool registered =await _authService.RegisterAsync(input.Email, input.Password);

        if (!registered)
        {
            return Conflict("User with that email already exists.");
        }

        return Created("", new{input.Email, Role = Roles.User });
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest input)
    {
        var result = await _authService.LoginAsync(input.Email,input.Password);

        if (result == null)
        {
            return Unauthorized("Invalid email or password.");
        }

        return Ok(result);
    }
}