using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MoviesTVShows.Model;
using MoviesTVShows.Repository.Common;
using MoviesTVShows.Service.Common;
using MoviesTVShows.Service.Common.Exceptions;
using MoviesTVShows.Service.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesTVShows.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, ITokenService tokenService, ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            var existingUser = await _userRepository.GetByEmailAsync(email);

            if (existingUser != null)
            {
                throw new ConflictException("User with that email already exists.");
            }

            var user = new User
            {
                Email = email,
                Role = Roles.User
            };

            user.Passwordhash = _passwordHasher.HashPassword(user, password);

            await _userRepository.AddAsync(user);

            return true;
        }

        public async Task<LoginResult?> LoginAsync(string email,string password)
        {
            var user =await _userRepository.GetByEmailAsync(email);

            if (user == null)
            {
                _logger.LogWarning("Failed login attempt. User was not found.");

                return null;
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Passwordhash,password);

            if (result == PasswordVerificationResult.Failed)
            {
                _logger.LogWarning("Failed login attempt for user {UserId}, wrong password.", user.Id);
                return null;
            }

            string token = _tokenService.CreateToken(user);

            return new LoginResult
            {
                Token = token,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
