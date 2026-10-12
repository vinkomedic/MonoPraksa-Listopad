using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesTVShows.Service.Common
{
    public class LoginResult
    {
        public string Token { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
