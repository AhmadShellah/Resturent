using DataCenter.Base;

namespace DataCenter.GenricRepo
{
    public class UpdateRepository<TEntity> : IUpdateRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ISaveChanges _saveChanges;

        public UpdateRepository(ApplicationDbContext context, ISaveChanges saveChanges)
        {
            _context = context;
            _saveChanges = saveChanges;
        }

        public async Task<TEntity> UpdateAsync(TEntity input, bool autoSave = false)
        {
            var result = _context.Set<TEntity>().Update(input);

            _context.SaveChanges();
            //await _saveChanges.SaveChangesAsync(autoSave: autoSave);

            return result.Entity;
        }

        public async Task UpdateManyAsync(List<TEntity> inputs, bool autoSave = false)
        {
            _context.Set<TEntity>().UpdateRange(inputs);

            await _saveChanges.SaveChangesAsync(autoSave: autoSave);
        }
    }
}