using MoviesTVShows.Model;
using MoviesTVShows.Service.Common.DTOs;

namespace MoviesTVShows.Service.Common;

public interface IMovieService
{
    Task<List<MovieResponse>> GetAllMoviesAsync();
    Task<MovieResponse?> GetMovieByIdAsync(Guid id);

    Task<Movie> AddMovieAsync(Movie movie);
    Task<bool> DeleteMovieAsync(Guid id);
}
