using DataCenter.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataCenter.GenricRepo
{
    public class RemoveRepository<TEntity> : IRemoveRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ISaveChanges _saveChanges;

        public RemoveRepository(ApplicationDbContext context, ISaveChanges saveChanges)
        {
            _context = context;
            _saveChanges = saveChanges;
        }

        public async Task<bool> RemoveAsync(Guid id, bool autoSave = false)
        {
            var entity = await _context.Set<TEntity>().FirstAsync(e => e.IsDeleted != true && e.Id == id);
            if (entity != null)
            {
                entity?.SetIsDeleted();
                await _saveChanges.SaveChangesAsync(autoSave);
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveRangeAsync(Expression<Func<TEntity, bool>> filter, bool autoSave = false)
        {
            var entites = await _context.Set<TEntity>().Where(e => e.IsDeleted != true)
                .Where(filter)
                .ToListAsync();
            if (entites != null)
            {
                entites.ForEach(e => e.SetIsDeleted());
                await _saveChanges.SaveChangesAsync(autoSave);
                return true;
            }
            return false;
        }
    }
}
