using System;
using System.Collections.Generic;
using System.Text;
using MoviesTVShows.Model;

namespace MoviesTVShows.Service.Common
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(string email, string password);

        Task<User?> LoginAsync(string email, string password);
    }
}
