using DataCenter.Base;

namespace DataCenter.GenricRepo
{
    public interface IRepository<TEntity> :
        ICreateRepository<TEntity>,
        IUpdateRepository<TEntity>,
        ISaveChanges,
        IGetRepository<TEntity>,
        IRemoveRepository<TEntity>
        where TEntity : BaseEntity
    {

    }
}