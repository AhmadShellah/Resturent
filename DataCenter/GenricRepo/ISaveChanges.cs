using DataCenter.Base;

namespace DataCenter.GenricRepo
{
    public interface ISaveChanges<TEntity> where TEntity : BaseEntity
    {
        void SaveChanges();

        Task SaveChangesAsync(bool autoSave = false);
    }
}
