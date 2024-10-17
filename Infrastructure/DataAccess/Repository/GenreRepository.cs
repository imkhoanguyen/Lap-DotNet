using Application.Abstract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly BookContext _context;
        public GenreRepository(BookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            var query = _context.Genres.AsQueryable();
            return await query.ToListAsync();
        }
    }
}
