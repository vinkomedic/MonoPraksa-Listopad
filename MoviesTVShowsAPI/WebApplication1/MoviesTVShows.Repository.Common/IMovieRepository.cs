using MoviesTVShows.Model;

namespace MoviesTVShows.Repository.Common
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAll();
        Task<Movie?> GetById(Guid id);
        Task Add(Movie movie);
        Task Delete(Movie movie);
    }
}
