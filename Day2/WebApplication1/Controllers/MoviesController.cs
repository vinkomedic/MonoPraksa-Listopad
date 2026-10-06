using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesAndTVShowsController : ControllerBase
    {
        public class Movie
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Year { get; set; }
            public double Rating { get; set; }
            public string Genre { get; set; }
        }

        public class TVShow
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Episodes { get; set; }

            public double Rating { get; set; }

        }

       
        public static List<TVShow> shows = new List<TVShow>()
        {
            new TVShow
            {
                Id = 1,
                Title = "2 and a half men",
                Episodes = 96,
                Rating = 8.2
            },

            new TVShow
            {
                Id= 2,
                Title = "Game of Thrones",
                Episodes = 65,
                Rating = 7.5
            },

            new TVShow
            {
                Id=3,
                Title= "Big Bang Theory",
                Episodes = 112,
                Rating = 6.6
            }
        };
        private static List<Movie> movies = new List<Movie>()
        {
            new Movie
            {
                Id = 1,
                Title = "Gladiator",
                Year = 2000,
                Rating = 9.5,
                Genre = "Action"
            },

            new Movie
            {
                Id = 2,
                Title = "Interstellar",
                Year = 2014,
                Rating = 9.2,
                Genre = "Scfi"
            },

            new Movie
            {
                Id = 3,
                Title = "Deadpool 2",
                Year = 2021,
                Rating = 7.5,
                Genre = "Action"
            },

            new Movie
            {
                Id = 4,
                Title = "Ted",
                Year = 2018,
                Rating = 7.8,
                Genre = "Comedy"
            }
        };


        
        [HttpGet("TVShows")]
        public IActionResult GetTVShows()
        {
            return Ok(shows);
        }

        [HttpGet("Movies")]
        public IActionResult GetMovies() 
        {
            return Ok(movies);
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                Movies = movies,
                TVShows = shows
            });
        }

        [HttpGet("{genre}")]
        public IActionResult GetMoviesByGenre(string genre)
        {
            var result = movies.Where(m =>m.Genre.ToLower() == genre.ToLower()).ToList();

            if (result.Count == 0) 
            {
                return NotFound("Genre not found");           
            }
            
            return Ok(result);
        }

        [HttpGet("RatingMovies/asc")]
        public IActionResult GetMoviesByRatingAsc()
        {
            var result = movies.OrderBy(m => m.Rating).ToList();

            return Ok(result);
        }

        [HttpGet("RatingMovies/desc")]
        public IActionResult GetMoviesByRatingDescending()
        {
            var result = movies.OrderByDescending(m => m.Rating).ToList();

            return Ok(result);
        }

        [HttpGet("TVSHows/filter")]
        public IActionResult GetTVShowsFilter(double? minRating, double? maxRating, int? maxEpisodes, int? minEpisodes)
        {
            var result = shows.AsEnumerable();

            if (minRating.HasValue)
            {
                result = result.Where(show => show.Rating >= minRating.Value);
            }
            if ( maxRating.HasValue)
            {
                result = result.Where(show => show.Rating <= maxRating.Value);
            }
            if (maxEpisodes.HasValue)
            {
                result = result.Where(show => show.Episodes <= maxEpisodes.Value);
            }
            if (minEpisodes.HasValue)
            {
                result = result.Where(show => show.Episodes >= minEpisodes.Value);
            }

            return Ok(result.ToList());
        }

        [HttpGet("Movies/filter")]
        public IActionResult GetMoviesFilter(double? minRating,int? minYear)
        {
            var result = movies.AsEnumerable();

            if (minRating.HasValue)
            {
                result = result.Where(movie => movie.Rating >= minRating.Value);
            }
            if (minYear.HasValue)
            {
                result = result.Where(movie => movie.Year >= minYear.Value);
            }
           

            return Ok(result.ToList());
        }

        [HttpPut("TVShows/{id}")]
        public IActionResult UpdateTVShow(int id, TVShow updatedShow)
        {
            var show = shows.FirstOrDefault(s => s.Id == id);

            if (show == null)
            {
                return NotFound("TV show not found.");
            }

            show.Title = updatedShow.Title;
            show.Episodes = updatedShow.Episodes;
            show.Rating = updatedShow.Rating;

            return Ok(show);
        }

        [HttpPost("Movies")]
        public IActionResult AddMovie(Movie movie) 
        {
            foreach(var Movie in movies)
            {
                if(movie.Id == Movie.Id)
                {
                    return Conflict("Movie with that Id already exists");
                }
            }
            movies.Add(movie);

            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id) 
        {
            Movie movie = movies.FirstOrDefault(m => m.Id == id); 

            if (movie == null)
            {
                return NotFound();
            }

            movies.Remove(movie);

            return NoContent();
        }
    }

    
}