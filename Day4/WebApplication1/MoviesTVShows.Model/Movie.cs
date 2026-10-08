using System;
using System.Collections.Generic;

namespace MoviesTVShows.Model;

public partial class Movie
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public int Year { get; set; }

    public decimal? Rating { get; set; }

    public Guid? Genreid { get; set; }

    public int? Durationmin { get; set; }

    public virtual Genre? Genre { get; set; }
}
