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
        public IActionResult GetMovies()
        {
            return Ok(_service.GetAllMovies());
        }

        [HttpPost("Movies")]
        public IActionResult AddMovie(Movie movie)
        {
            bool added = _service.AddMovie(movie);

            if (!added)
            {
                return Conflict("Movie with that Id already exists");
            }

            return Ok(movie);
        }

        [HttpDelete("Movies/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            bool deleted = _service.DeleteMovie(id);

            if(!deleted)
            {
                return NotFound();
            }

            return NotFound();
        }
    }
}

    