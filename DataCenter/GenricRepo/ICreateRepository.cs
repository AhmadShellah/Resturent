using DataCenter.Base;

namespace DataCenter.GenricRepo
{
    public interface ICreateRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Create(TEntity input, bool autoSave = false);

        public Task<TEntity> CreateAsync(TEntity input, bool autoSave = false);

        public Task CreateManyAsync(List<TEntity> inputs, bool autoSave = false);
    }
}
