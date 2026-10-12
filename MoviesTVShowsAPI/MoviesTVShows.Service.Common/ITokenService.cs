using MoviesTVShows.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesTVShows.Service.Common
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
