using System;
using System.Collections.Generic;

namespace MoviesTVShows.Model;

public partial class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public string Role { get; set; } = null!;
}
