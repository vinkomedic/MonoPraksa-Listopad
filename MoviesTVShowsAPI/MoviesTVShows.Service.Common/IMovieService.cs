using MoviesTVShows.Model;
using MoviesTVShows.Service.Common.DTOs;

namespace MoviesTVShows.Service.Common;

public interface IMovieService
{
    Task<List<MovieResponse>> GetAllMoviesAsync();
    Task<MovieResponse?> GetMovieByIdAsync(Guid id);

    Task<bool> DeleteMovieAsync(Guid id);
    Task<MovieResponse> AddMovieAsync(MovieAdd input);
}
