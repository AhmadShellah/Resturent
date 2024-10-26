using DataCenter.Base;
using System.Linq.Expressions;

namespace Repositorys
{
    public interface IBasicRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<List<TEntity>> GetListAsync();

        public Task<TEntity> GetByIdAsync(Guid id);

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter);

        public Task<IQueryable<TEntity>> GetIQueryableAsync(Expression<Func<TEntity, bool>> filter = null);

        public IQueryable<TEntity> GetIQueryable(Expression<Func<TEntity, bool>>? filter = null,
            params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes);
    }
}
