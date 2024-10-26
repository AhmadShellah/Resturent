

using Contracts.AllModels.OredrsModels;
using DataCenter.Base;

namespace DataCenter.GenricRepo
{
    public interface ICreateRepo<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity> Create(TEntity input);
    }
}
