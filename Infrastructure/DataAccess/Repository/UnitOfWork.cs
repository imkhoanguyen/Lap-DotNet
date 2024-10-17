using Application.Abstract;

namespace Infrastructure.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookContext _context;
        public IBookRepository Book { get; private set; }
        public IGenreRepository Genre { get; private set; }
        public UnitOfWork(BookContext context)
        {
            _context = context;
            Book = new BookRepository(_context);
            Genre = new GenreRepository(_context);
        }

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
