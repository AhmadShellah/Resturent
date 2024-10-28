

using DataCenter.Base;
using System.Linq.Expressions;

namespace DataCenter.GenricRepo
{
    public interface IRemoveRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<bool> RemoveAsync(Guid id, bool autoSave = false);
        public Task<bool> RemoveRangeAsync(Expression<Func<TEntity, bool>> filter, bool autoSave = false);
    }
}
