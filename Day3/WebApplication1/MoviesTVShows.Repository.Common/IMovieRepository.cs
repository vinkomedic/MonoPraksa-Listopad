using MoviesTVShows.Model;

namespace MoviesTVShows.Repository.Common
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        void Add(Movie movie);
        void Delete(Movie movie);
        Movie? GetById(int id);
    }
}
