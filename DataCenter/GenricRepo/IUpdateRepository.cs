using DataCenter.Base;

namespace DataCenter.GenricRepo
{
    public interface IUpdateRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity> UpdateAsync(TEntity input, bool autoSave = false);

        public Task UpdateManyAsync(List<TEntity> inputs, bool autoSave = false);
    }
}
