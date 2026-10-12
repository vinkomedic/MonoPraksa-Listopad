using MoviesTVShows.Model;

namespace MoviesTVShows.Repository.Common
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(Guid id);
        Task AddAsync(Movie movie);
        Task DeleteAsync(Movie movie);
    }
}
