using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Entities;
using DataAccess.Repositories.Generic;
using DataAccess.Repositories.Specific;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Implementation
{
    public class MealRepository(ApplicationDbContext context, 
        IMapper mapper, 
        IGetRepository<Meal> getRepository,
        ICreateRepository<Meal> createRepository,
        IRemoveRepository<Meal> removeRepository) : IMealRepository
    {
        private readonly ApplicationDbContext _context = context;

        private readonly IMapper _mapper = mapper;

        private readonly IGetRepository<Meal> _getRepository = getRepository;

        private readonly ICreateRepository<Meal> _createRepository = createRepository;

        private readonly IRemoveRepository<Meal> _removeRepository = removeRepository;

        public async Task<MealModel> CreateAsync(MealModel model, bool? saving = false)  // model => entity =>(DB) => model => BL
        {
            var entity = _mapper.Map<Meal>(model);

            await _createRepository.CreateAsync(entity, saving);

            return _mapper.Map<MealModel>(entity);
        }

        public async Task RemoveAsync(Guid id, bool? saving = false)
        {
            await _removeRepository.RemoveAsync(id, saving);
        }

        public async Task<MealModel> GetByIdAsync(Guid id)
        {
            var mealToReturn = await _getRepository.GetByIdAsync(id);

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

        public async Task<IEnumerable<MealModel>> GetAllAsync(Expression<Func<Meal, bool>> filter)
        {
            var result = await _getRepository.GetAllAsync(filter);

            var mapping = _mapper.Map<List<MealModel>>(result);

            return mapping;
        }

        public async Task<IEnumerable<MealModel>> GetAllAsync()
        {
            var result = await _getRepository.GetAllAsync();

            var mapping = _mapper.Map<IEnumerable<MealModel>>(result);

            return mapping;
        }
    }
}