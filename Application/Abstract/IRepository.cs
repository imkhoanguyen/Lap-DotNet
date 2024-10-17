using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression, bool tracked = false);
        void Remove(T entity);
        void Update(T entity);
    }
}
