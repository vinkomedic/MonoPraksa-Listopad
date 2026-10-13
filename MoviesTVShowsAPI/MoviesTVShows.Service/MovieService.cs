using MoviesTVShows.Model;
using MoviesTVShows.Repository.Common;
using MoviesTVShows.Service.Common;
using MoviesTVShows.Service.Common.DTOs;

namespace MoviesTVShows.Service;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;

    public MovieResponse MapToResponse(Movie movie)
    {
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

    public async Task<MovieResponse> AddMovieAsync(MovieAdd input)
    {
        var movie = new Movie
        {
            Title = input.Title,
            Year = input.Year,
            Rating = input.Rating,
            Genreid = input.Genreid,
            Durationmin = input.Durationmin
        };

        await _repository.AddAsync(movie);

        var addedMovie = await _repository.GetByIdAsync(movie.Id);

        if (addedMovie == null)
        {
            throw new InvalidOperationException(
                "Movie could not be retrieved after creation."
            );
        }

        return MapToResponse(addedMovie);
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
