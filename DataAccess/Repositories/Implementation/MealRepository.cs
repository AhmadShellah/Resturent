using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Implementation
{
    public class MealRepository(ApplicationDbContext context, IMapper mapper) : IMealRepository
    {
        private readonly ApplicationDbContext _context = context ?? 
            throw new ArgumentNullException(nameof(context));

        private readonly IMapper _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));

        public async Task<MealModel> CreateAsync(MealModel model)  // model => entity =>(DB) => model => BL
        {
            var entity = _mapper.Map<Meal>(model);

            await _context.Meals.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MealModel>(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var meal = await _context.Meals.FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted) ??
                throw new KeyNotFoundException($"Meal with id: {id} not found !!");

            meal.SetIsDeleted();

            await _context.SaveChangesAsync();
        }

        public async Task<MealModel> GetByIdAsync(Guid id)
        {
            var mealToReturn = await _context.Meals.FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted) ??
                throw new KeyNotFoundException($"Meal with id: {id} not found !!");

            return _mapper.Map<MealModel>(mealToReturn);
        }

        public async Task<MealModel> EditAsync(MealModel model)
        {
            var meal = await _context.Meals.FirstOrDefaultAsync(m => m.Id == model.Id && !m.IsDeleted) ??
                throw new KeyNotFoundException($"Meal with id: {model.Id} not found !!");

            _mapper.Map(model, meal);

            _context.Meals.Update(meal);
            await _context.SaveChangesAsync();

            return _mapper.Map<MealModel>(meal);
        }

        public async Task<IEnumerable<MealModel>> GetAllAsync(Expression<Func<Meal, bool>>? filter = null)
        {
            return await _context.Meals.Where(m => !m.IsDeleted) 
                                 .Where(filter ?? (om => true))
                                 .Select(m => _mapper.Map<MealModel>(m))
                                 .ToListAsync();
        }
    }
}
