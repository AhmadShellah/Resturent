using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repositories.Generic;

namespace DataAccess.Repositories.Implementation
{
    public class CreateRepository<TEntity>(ApplicationDbContext context) : ICreateRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _context = context; 

        public async Task CreateAsync(TEntity entity, bool? saving = false)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            if(saving == true)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities, bool? saving = false)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);

            if(saving == true)
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}