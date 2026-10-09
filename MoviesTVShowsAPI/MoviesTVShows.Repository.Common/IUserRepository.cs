using System;
using System.Collections.Generic;
using System.Text;
using MoviesTVShows.Model;

namespace MoviesTVShows.Repository.Common
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
