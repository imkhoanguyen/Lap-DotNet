using Domain.Entities;

namespace Application.Abstract
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetAllAsync();
    }
}
