using MoviesTVShows.Model;


namespace MoviesTVShows.Service.Common
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMovies();
        Task<bool> AddMovie(Movie movie);
        Task<bool> DeleteMovie(Guid id);
    }
}
