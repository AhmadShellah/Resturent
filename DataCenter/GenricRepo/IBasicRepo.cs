using DataCenter.Base;

namespace DataCenter.GenricRepo
{
    public interface IBasicRepo<TEntity> where TEntity : class
    {
        public Task<TEntity> GetByIdAsync(Guid id);

        public Task<List<TEntity>> GetListAsync();
    }
}
