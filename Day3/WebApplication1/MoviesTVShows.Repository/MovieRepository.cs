using MoviesTVShows.Model;
using MoviesTVShows.Repository.Common;

namespace MoviesTVShows.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private static List<Movie> movies = new List<Movie>()
        {
        new Movie
        {
            Id=1,
            Title = "Gladiator",
            Year = 2000,
            Rating = 9.5,
            Genre = "Action"
        },

        new Movie
        {
            Id= 2,
            Title = "Interstellar",
            Year = 2014,
            Rating = 9.2,
            Genre = "Sci-Fi"
        }
        };

        public List<Movie> GetAll()
        {
            return movies;
        }
        public Movie? GetById(int id)
        {
            return movies.FirstOrDefault(m => m.Id == id);
        }
        public void Add(Movie movie)
        {
            movies.Add(movie);
        }
        public void Delete(Movie movie)
        {
            movies.Remove(movie);
        }
    }
}
