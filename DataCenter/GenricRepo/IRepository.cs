using DataCenter.Base;

namespace DataCenter.GenricRepo
{
    public interface IRepository<TEntity> : ICreateRepository<TEntity>,
        IUpdateRepository<TEntity>,
        ISaveChanges<TEntity>,
        IGetRepository<TEntity>
        where TEntity : BaseEntity
    {

    }
}
