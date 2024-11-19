using Microsoft.EntityFrameworkCore;
using movies.Dots;
using movies.models;

namespace movies.Services
{
    public class GenresService : IGenresService
    {
        private readonly ApplicationDbContext _context;

        public GenresService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> Add(Genre genre)
        {
           await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> delete(Genre genre)
        {
              _context.Genres.Remove(genre);
          await  _context.SaveChangesAsync();
            return genre;

        }

        public async Task<IEnumerable<Genre>> getall()
        {
             return await _context.Genres
               .ToListAsync();
        }

        public async Task<Genre> getbyId(int id)
        {
            return await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Genre> Update(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
            return genre;
        }
    }
}
