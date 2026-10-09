namespace MoviesTVShows.DTOs;

public class MovieAdd
{
    public string Title { get; set; } = null!;

    public int Year { get; set; }

    public decimal? Rating { get; set; }

    public Guid? Genreid { get; set; }

    public int? Durationmin { get; set; }
}
