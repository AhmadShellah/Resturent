using DataCenter.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace DataCenter.GenricRepo
{
    public class BasicRepo<TEntity> : IBasicRepo<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        public BasicRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<TEntity>().FindAsync(id);
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

        public async Task<IQueryable<TEntity>> GetIQueryableAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var result = _context.Set<TEntity>().Where(s => s.IsDeleted != true);
            if (filter is null)
            {
                return result;
            }
            result = result.Where(filter);
            return result;
        }
    }
}