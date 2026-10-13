using Microsoft.AspNetCore.Mvc;
using MoviesTVShows.DTOs;
using MoviesTVShows.Model;
using MoviesTVShows.Service.Common;
using Microsoft.AspNetCore.Authorization;
using MoviesTVShows.Service.Common.DTOs;

namespace MoviesAndTVShows.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class MoviesAndTVShowsController : ControllerBase
{
    private readonly IMovieService _service;

    public MoviesAndTVShowsController(IMovieService service)
    {
        _service = service;
    }

    [HttpGet("Movies")]
    public async Task<IActionResult> GetMovies()
    {
        var movies = await _service.GetAllMoviesAsync();

        return Ok(movies);
    }


    [HttpGet("Movies/{id}")]
    public async Task<IActionResult> GetMovieById(Guid id)
    {
        var movie = await _service.GetMovieByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPost("Movies")]
    public async Task<IActionResult> AddMovie(MovieAdd input)
    {
        var response = await _service.AddMovieAsync(input);

        return CreatedAtAction(nameof(GetMovieById), new { id = response.Id }, response);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("Movies/{id}")]
    public async Task<IActionResult> DeleteMovie(Guid id)
    {
        bool deleted = await _service.DeleteMovieAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
