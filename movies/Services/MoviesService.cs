using Microsoft.EntityFrameworkCore;
using movies.models;

namespace movies.Services
{
    public class MoviesService : IMoviesService
    {

        readonly ApplicationDbContext _context;

        public MoviesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> Add(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<IEnumerable<Movie>> getall()
        {

         return await _context.Movies.Include(d => d.Genre)
                .ToListAsync();
        }

        public async Task<Movie> getbyId(int id)
        {
            return await _context.Movies.Include(d => d.Genre)
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Movie> Update(Movie movie)
        {

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
