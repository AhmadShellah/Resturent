using DataAccess.Entities;
using DataAccess.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Implementation
{
    public class GetRepository<TEntity>(ApplicationDbContext context) : IGetRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().Where(e => e.IsDeleted != true).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.IsDeleted != true && e.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().Where(e => e.IsDeleted != true)
                .Where(filter)
                .ToListAsync();
        }

        public IQueryable<TEntity> GetIQueryableAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            var result = _context.Set<TEntity>().Where(e => !e.IsDeleted);
            if (filter is null)
            {
                return result;
            }

            result = result.Where(filter);

            return result;
        }

/*        public IQueryable<TEntity> GetIQueryableAsync(
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
        }*/
    }
}
