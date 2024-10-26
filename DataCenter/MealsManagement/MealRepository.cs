using AutoMapper;
using Contracts.AllModels.MealsModels;
using DataCenter.GenricRepo;
using DataCenter.MealsManagement;

namespace DataCenter.MealManagement
{
    public class MealRepository : IMealRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Meal> _repository;

        public MealRepository(IMapper mapper, IRepository<Meal> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<MealModel>> GetMealsList()
        {
            var result = await _repository.GetListAsync(s => s.Description == "Ahmad");

            var mapping = _mapper.Map<List<MealModel>>(result);

            return mapping;
        }

        public MealModel CreateObjectInDataBase(MealModel inputFromDeveloper)
        {
            var mappingToInsert = _mapper.Map<MealModel, Meal>(inputFromDeveloper);

            _repository.Create(mappingToInsert, true);

            var mappingToReturn = _mapper.Map<Meal, MealModel>(mappingToInsert);

            return mappingToReturn;
        }



        public MealModel Create(MealModel inputFromDeveloper)
        {
            var mappingToInsert = _mapper.Map<MealModel, Meal>(inputFromDeveloper);

            _repository.Create(mappingToInsert, true);

            var mappingToReturn = _mapper.Map<Meal, MealModel>(mappingToInsert);

            return mappingToReturn;
        }

    }
}
