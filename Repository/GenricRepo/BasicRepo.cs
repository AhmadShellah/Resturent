
using DataCenter;
using DataCenter.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositorys
{
    public class BasicRepository<TEntity> : IBasicRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public BasicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<TEntity>().FindAsync(id);

            return result;
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            var result = await _context.Set<TEntity>().ToListAsync();

            return result;
        }

        public async Task<IQueryable<TEntity>> GetIQueryableAsync(
            Expression<Func<TEntity, bool>> filter = null)
        {
            var result = _context.Set<TEntity>().Where(s => s.IsDeleted != true);
            if (filter is null)
            {
                return result;
            }

            result = result.Where(filter);

            return result;
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = await _context.Set<TEntity>()
                .Where(filter)
                .Where(s => s.IsDeleted != true)
                .ToListAsync();

            return result;
        }

        public IQueryable<TEntity> GetIQueryable(
                    Expression<Func<TEntity, bool>>? filter = null,
                    params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes)
        {
            // Apply the base filter
            var result = _context.Set<TEntity>().Where(e => !e.IsDeleted);

            // Apply the filter if provided
            if (filter != null)
            {
                result = result.Where(filter);
            }

            // Apply each include function
            foreach (var include in includes)
            {
                result = include(result);
            }

            return result;
        }

    }
}
