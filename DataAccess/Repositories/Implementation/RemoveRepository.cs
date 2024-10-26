using DataAccess.Entities;
using DataAccess.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Implementation
{
    public class RemoveRepository<TEntity>(ApplicationDbContext context) : IRemoveRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _context = context;

        public async Task RemoveAsync(Guid id, bool? saving = false)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.IsDeleted != true && e.Id == id);

            entity?.SetIsDeleted();

            if(saving == true)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveRangeAsync(Expression<Func<TEntity, bool>> filter, bool? saving = false)
        {
            var entites = await _context.Set<TEntity>().Where(e => e.IsDeleted != true)
                .Where(filter)
                .ToListAsync();

            entites.ForEach(e => e.SetIsDeleted());

            if(saving == true)
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}
