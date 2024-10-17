
using Application.Abstract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BookContext _context;
        public Repository(BookContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }


        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> expression, bool tracked = false)
        {
            if (tracked)
            {
                var entityTracked = await _context.Set<T>().FirstOrDefaultAsync(expression);
                return entityTracked;
            }

            var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
            return entity;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
