using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using MoviesTVShows.Model;
using MoviesTVShows.Service.Common;


namespace MoviesTVShows.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            var movies = await _service.GetAllMovies();
            return Ok(movies);
        }

        [HttpPost("Movies")]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            bool added = await _service.AddMovie(movie);

            if (!added)
            {
                return Conflict("Movie with that Id already exists.");
            }

            return Ok(movie);
        }

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
}

    