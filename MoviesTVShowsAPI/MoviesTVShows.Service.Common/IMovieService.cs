using MoviesTVShows.Model;

namespace MoviesTVShows.Service.Common;

public interface IMovieService
{
    Task<List<Movie>> GetAllMovies();
    Task<Movie?> GetMovieById(Guid id);
    Task<Movie> AddMovie(Movie movie);
    Task<bool> DeleteMovie(Guid id);
}
