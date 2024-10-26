using DataAccess.Entities;

namespace DataAccess.Repositories.Generic
{
    public interface ICreateRepository<TEntity> where TEntity : BaseEntity
    {
        Task CreateAsync(TEntity entity, bool? saving = false);
        Task CreateRangeAsync(IEnumerable<TEntity> entities, bool? saving = false);
    }
}
