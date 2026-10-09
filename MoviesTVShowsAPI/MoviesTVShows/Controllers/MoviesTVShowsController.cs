using Microsoft.AspNetCore.Mvc;
using MoviesTVShows.DTOs;
using MoviesTVShows.Model;
using MoviesTVShows.Service.Common;
using Microsoft.AspNetCore.Authorization;

namespace MoviesTVShows.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesAndTVShowsController : ControllerBase
{
    private readonly IMovieService _service;

    public MoviesAndTVShowsController(IMovieService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet("Movies")]
    public async Task<IActionResult> GetMovies()
    {
        var movies = await _service.GetAllMovies();

        var response = movies.Select(movie => new MovieResponse
        {
            Id = movie.Id,
            Title = movie.Title,
            Year = movie.Year,
            Rating = movie.Rating,
            Genre = movie.Genre?.Name,
            Durationmin = movie.Durationmin
        }).ToList();

        return Ok(response);
    }

    [Authorize]
    [HttpGet("Movies/{id}")]
    public async Task<IActionResult> GetMovieById(Guid id)
    {
        var movie = await _service.GetMovieById(id);

        if (movie == null)
        {
            return NotFound();
        }

        var response = new MovieResponse
        {
            Id = movie.Id,
            Title = movie.Title,
            Year = movie.Year,
            Rating = movie.Rating,
            Genre = movie.Genre?.Name,
            Durationmin = movie.Durationmin
        };

        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("Movies")]
    public async Task<IActionResult> AddMovie(MovieAdd input)
    {
        var movie = new Movie
        {
            Title = input.Title,
            Year = input.Year,
            Rating = input.Rating,
            Genreid = input.Genreid,
            Durationmin = input.Durationmin
        };

        var addedMovie = await _service.AddMovie(movie);
        var movieFromDatabase = await _service.GetMovieById(addedMovie.Id);

        var response = new MovieResponse
        {
            Id = movieFromDatabase!.Id,
            Title = movieFromDatabase.Title,
            Year = movieFromDatabase.Year,
            Rating = movieFromDatabase.Rating,
            Genre = movieFromDatabase.Genre?.Name,
            Durationmin = movieFromDatabase.Durationmin
        };

        return CreatedAtAction(
            nameof(GetMovieById),
            new { id = addedMovie.Id },
            response
        );
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("Movies/{id}")]
    public async Task<IActionResult> DeleteMovie(Guid id)
    {
        bool deleted = await _service.DeleteMovie(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
