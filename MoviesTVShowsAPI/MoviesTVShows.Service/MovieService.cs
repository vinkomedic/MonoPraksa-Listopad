using MoviesTVShows.Model;
using MoviesTVShows.Repository.Common;
using MoviesTVShows.Service.Common;
using MoviesTVShows.Service.Common.DTOs;

namespace MoviesTVShows.Service;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;

    public MovieService(IMovieRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MovieResponse>> GetAllMoviesAsync()
    {
        var movies = await _repository.GetAllAsync();

        return movies.Select(movie => new MovieResponse
        {
            Id = movie.Id,
            Title = movie.Title,
            Year = movie.Year,
            Rating = movie.Rating,
            Genre = movie.Genre?.Name,
            Durationmin = movie.Durationmin
        }).ToList();
    }

    public async Task<MovieResponse?> GetMovieByIdAsync(Guid id)
    {
        var movie = await _repository.GetByIdAsync(id);

        if (movie == null)
        {
            return null;
        }

        return new MovieResponse
        {
            Id = movie.Id,
            Title = movie.Title,
            Year = movie.Year,
            Rating = movie.Rating,
            Genre = movie.Genre?.Name,
            Durationmin = movie.Durationmin
        };
    }

    public async Task<Movie> AddMovieAsync(Movie movie)
    {
        await _repository.AddAsync(movie);
        return movie;
    }

    public async Task<bool> DeleteMovieAsync(Guid id)
    {
        var movie = await _repository.GetByIdAsync(id);

        if (movie == null)
        {
            return false;
        }

        await _repository.DeleteAsync(movie);
        return true;
    }
}
