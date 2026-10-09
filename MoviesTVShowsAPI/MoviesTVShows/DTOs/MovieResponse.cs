namespace MoviesTVShows.DTOs;

public class MovieResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public int Year { get; set; }

    public decimal? Rating { get; set; }

    public string? Genre { get; set; }

    public int? Durationmin { get; set; }
}
