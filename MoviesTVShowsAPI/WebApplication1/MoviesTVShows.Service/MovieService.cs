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

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _repository.GetAll();
        }

        public async Task<bool> AddMovie(Movie movie)
        {
            var existingMovie = await _repository.GetById(movie.Id);

            if (existingMovie != null)
            {
                return false;
            }

            await _repository.Add(movie);

            return true;
        }

        public async Task<bool> DeleteMovie(Guid id)
        {
            var movie = await _repository.GetById(id);

            if (movie == null)
            {
                return false;
            }

            await _repository.Delete(movie);

            return true;
        }
    }
}
