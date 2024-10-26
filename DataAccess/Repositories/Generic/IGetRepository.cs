using DataAccess.Entities;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Generic
{
    public interface IGetRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity?> GetByIdAsync(Guid id);
        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        
        public IQueryable<TEntity> GetIQueryableAsync(Expression<Func<TEntity, bool>>? filter = null);

    }
}
