using AutoMapper;
using Contracts.AllModels.MealsModels;

namespace DataCenter.MealsManagement
{
    public class MealsRepository
    {
        private readonly static List<Meals> _meals = new();
        private readonly IMapper _mapper;

        public MealsRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public MealModel CreateObjectInDataBase(MealModel inputFromDeveloper)
        {
            var mappingToInsert = _mapper.Map<MealModel, Meals>(inputFromDeveloper);

            _meals.Add(mappingToInsert);

            var mappingToReturn = _mapper.Map<Meals, MealModel>(mappingToInsert);

            return mappingToReturn;
        }

    }
}
