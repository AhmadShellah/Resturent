using AutoMapper;
using Contracts.AllModels.MealsModels;

namespace DataCenter.MealManagement
{
    public class MealRepository
    {
        private readonly static List<Meal> _Meal = new();
        private readonly IMapper _mapper;

        public MealRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public MealModel CreateObjectInDataBase(MealModel inputFromDeveloper)
        {
            var mappingToInsert = _mapper.Map<MealModel, Meal>(inputFromDeveloper);

            _Meal.Add(mappingToInsert);

            var mappingToReturn = _mapper.Map<Meal, MealModel>(mappingToInsert);

            return mappingToReturn;
        }

        public MealModel Create(MealModel inputFromDeveloper)
        {
            var mappingToInsert = _mapper.Map<MealModel, Meal>(inputFromDeveloper);

            _Meal.Add(mappingToInsert);

            var mappingToReturn = _mapper.Map<Meal, MealModel>(mappingToInsert);

            return mappingToReturn;
        }

    }
}
