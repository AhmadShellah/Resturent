using AutoMapper;
using Contracts.AllModels.MealsModels;
using DataCenter.GenricRepo;
using DataCenter.MealsManagement;

namespace DataCenter.MealManagement
{
    public class MealRepository : IMealRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Meal> _Repository;

        public MealRepository(IMapper mapper, IRepository<Meal> Repository)
        {
            _mapper = mapper;
            _Repository = Repository;
        }

        public async Task<MealModel> Create(MealModel inputFromDeveloper)
        {
            var mappingToInsert = _mapper.Map<MealModel, Meal>(inputFromDeveloper);

            var result = await _Repository.CreateAsync(mappingToInsert, true);

            var mappingToReturn = _mapper.Map<Meal, MealModel>(result);

            return mappingToReturn;
        }

        public async Task<IEnumerable<MealModel>> GetMeals()
        {
            var meals = await _Repository.GetIQueryableAsync();

            return _mapper.Map<List<Meal>, List<MealModel>>(meals.ToList());
        }

        public async Task<MealModel> GetById(Guid id)
        {
            var meal = await _Repository.GetByIdAsync(id);

            return _mapper.Map<Meal, MealModel>(meal);
        }

        // Edit an existing meal
        public async Task<MealModel> EditMeal(MealModel updatedMealModel)
        {
            var meal = await _Repository.GetByIdAsync(updatedMealModel.Id);

            if (meal == null)
            {
                throw new KeyNotFoundException("Meal not Found");
            }

            _mapper.Map(updatedMealModel, meal);

            var editMeal = await _Repository.UpdateAsync(meal, true);

            var result = _mapper.Map<Meal, MealModel>(editMeal);

            return result;
        }


        public async Task<bool> DeleteMeal(Guid id)
        {
           return await _Repository.RemoveAsync(id,true);
        }
    }
}
