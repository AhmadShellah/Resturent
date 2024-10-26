using DataAccess.Entities;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Generic
{
    public interface IRemoveRepository<TEntity> where TEntity : BaseEntity
    {
        public Task RemoveAsync(Guid id, bool? saving = false);
        public Task RemoveRangeAsync(Expression<Func<TEntity, bool>> filter, bool? saving = false);
    }
}
