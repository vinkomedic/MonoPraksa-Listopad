using MoviesTVShows.Model;
using MoviesTVShows.Repository.Common;
using Microsoft.EntityFrameworkCore;

 namespace MoviesTVShows.Repository
    {
        public class MovieRepository : IMovieRepository
        {
            private readonly AppDbContext _context;

            public MovieRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Movie>> GetAll()
            {
                return await _context.Movies.ToListAsync();
            }

            public async Task<Movie?> GetById(Guid id)
            {
                return await _context.Movies
                    .FirstOrDefaultAsync(movie => movie.Id == id);
            }

            public async Task Add(Movie movie)
            {
                await _context.Movies.AddAsync(movie);
                await _context.SaveChangesAsync();
            }

            public async Task Delete(Movie movie)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
 }

