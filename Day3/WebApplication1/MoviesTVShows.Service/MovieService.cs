using MoviesTVShows.Model;
using MoviesTVShows.Repository.Common;
using MoviesTVShows.Service.Common;

namespace MoviesTVShows.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        { 
            _repository = repository;
        }

        public List<Movie> GetAllMovies()
        {
            return _repository.GetAll();
        }

        public bool AddMovie(Movie movie)
        {
            var existingMovie= _repository.GetById(movie.Id);

            if(existingMovie != null)
            {
                return false;
            }
            _repository.Add(movie);
            return true;
        }

        public bool DeleteMovie(int id)
        {
            var movie = _repository.GetById(id);
            
            if (movie == null)
            {
                return false;
            }

            _repository.Delete(movie);
            return true;
        }
    }
}
