using System.ComponentModel.DataAnnotations;

namespace MoviesTVShows.Service.Common.DTOs;

public class MovieAdd
{
    [Required]
    [StringLength(50)]
    public string Title { get; set; } = null!;

    [Range(1888, 2100)]
    public int Year { get; set; }

    [Range(0, 10)]
    public decimal? Rating { get; set; }

    public Guid? Genreid { get; set; }

    [Range(1, 1000)]
    public int? Durationmin { get; set; }
}