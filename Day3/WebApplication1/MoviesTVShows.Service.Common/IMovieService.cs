using MoviesTVShows.Model;


namespace MoviesTVShows.Service.Common
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        bool AddMovie(Movie movie);
        bool DeleteMovie(int id);
    }
}
