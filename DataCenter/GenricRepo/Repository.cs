using DataCenter.Base;
using System.Linq.Expressions;

namespace DataCenter.GenricRepo
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ISaveChanges _saveChanges;
        protected readonly IGetRepository<TEntity> _getRepository;
        protected readonly IUpdateRepository<TEntity> _updateRepository;
        protected readonly ICreateRepository<TEntity> _createRepository;
        protected readonly IRemoveRepository<TEntity> _RemoveRepository;

        public Repository(
            ISaveChanges saveChanges,
            IGetRepository<TEntity> getRepository,
            IUpdateRepository<TEntity> updateRepository,
            ICreateRepository<TEntity> createRepository, 
            IRemoveRepository<TEntity> removeRepository)
        {
            _saveChanges = saveChanges;
            _getRepository = getRepository;
            _updateRepository = updateRepository;
            _createRepository = createRepository;
            _RemoveRepository = removeRepository;
        }



        #region All Methods Create 

        public TEntity Create(TEntity input, bool autoSave = false)
        {
            return _createRepository.Create(input, autoSave);
        }

        public async Task<TEntity> CreateAsync(TEntity input, bool autoSave = false)
        {
            return await _createRepository.CreateAsync(input, autoSave);
        }

        public async Task CreateManyAsync(List<TEntity> inputs, bool autoSave = false)
        {
            await _createRepository.CreateManyAsync(inputs, autoSave);
        }

        #endregion


        #region All Get Methods 

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _getRepository.GetByIdAsync(id);
        }

        public IQueryable<TEntity> GetIQueryable(Expression<Func<TEntity, bool>>? filter = null, params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes)
        {
            return _getRepository.GetIQueryable(filter, includes);
        }

        public async Task<IQueryable<TEntity>> GetIQueryableAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _getRepository.GetIQueryableAsync(filter);
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            return await _getRepository.GetListAsync();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _getRepository.GetListAsync(filter);
        }

        #endregion


        #region Save Changes 

        public void SaveChanges()
        {
            _saveChanges.SaveChanges();
        }

        public async Task SaveChangesAsync(bool autoSave = true)
        {
            await _saveChanges.SaveChangesAsync(autoSave);
        }

        #endregion


        #region All Update Methods 

        public async Task<TEntity> UpdateAsync(TEntity input, bool autoSave = false)
        {
            return await _updateRepository.UpdateAsync(input, autoSave);
        }

        public async Task UpdateManyAsync(List<TEntity> inputs, bool autoSave = false)
        {
            await _updateRepository.UpdateManyAsync(inputs, autoSave);
        }

        #endregion

        #region All Remove 

        public async Task<bool> RemoveAsync(Guid id, bool autoSave = false)
        {
            return await _RemoveRepository.RemoveAsync(id, autoSave);
        }

        public async Task<bool> RemoveRangeAsync(Expression<Func<TEntity, bool>> filter, bool autoSave = false)
        {
            return await _RemoveRepository.RemoveRangeAsync(filter, autoSave);
        }

        #endregion
    }
}