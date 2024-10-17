using Application.Abstract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly BookContext _context;
        public BookRepository(BookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
           var query = _context.Books.AsQueryable();
            return await query.ToListAsync();
        }
    }
}
