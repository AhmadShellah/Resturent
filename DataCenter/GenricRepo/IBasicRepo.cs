using DataCenter.Base;
using System.Linq.Expressions;
namespace DataCenter.GenricRepo
{
    public interface IBasicRepo<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity> GetByIdAsync(Guid id);
        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter);

        public Task<IQueryable<TEntity>> GetIQueryableAsync(Expression<Func<TEntity, bool>> filter = null);
    }
}