using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataCenter.GenricRepo
{
    public class BasicRepo<TEntity> : IBasicRepo<TEntity> where TEntity : class
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

        public async Task<List<TEntity>> GetListAsync()
        {
            var result = await _context.Set<TEntity>().ToListAsync();

            return result;
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = await _context.Set<TEntity>()
                .Where(filter)
                .ToListAsync();

            return result;
        }
    }
}
