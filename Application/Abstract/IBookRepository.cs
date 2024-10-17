using Domain.Entities;

namespace Application.Abstract
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllAsync();
    }
}
