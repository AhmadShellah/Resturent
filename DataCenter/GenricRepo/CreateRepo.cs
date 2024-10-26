using DataCenter.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.GenricRepo
{
    public class CreateRepo<TEntity> : ICreateRepo<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public CreateRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Create(TEntity input)
        {
            var result = await _context.Set<TEntity>().AddAsync(input);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
