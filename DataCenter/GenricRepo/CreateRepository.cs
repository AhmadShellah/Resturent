using DataCenter.Base;

namespace DataCenter.GenricRepo
{
    public class CreateRepository<TEntity> : ICreateRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ISaveChanges _saveChanges;

        public CreateRepository(ApplicationDbContext context, ISaveChanges saveChanges)
        {
            _context = context;
            _saveChanges = saveChanges;
        }

        public async Task<TEntity> CreateAsync(TEntity input, bool autoSave = false)
        {
            var resultFromDataBase = await _context.Set<TEntity>().AddAsync(input);

            await _saveChanges.SaveChangesAsync(autoSave);

            return resultFromDataBase.Entity;
        }

        public TEntity Create(TEntity input, bool autoSave = false)
        {
            var resultFromDataBase = _context.Set<TEntity>().Add(input);

            if (autoSave)
            {
                _saveChanges.SaveChanges();
            }

            return resultFromDataBase.Entity;
        }

        public async Task CreateManyAsync(List<TEntity> inputs, bool autoSave = false)
        {
            await _context.Set<TEntity>().AddRangeAsync(inputs);

            await _saveChanges.SaveChangesAsync(autoSave);
        }
    }
}