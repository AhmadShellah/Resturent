using AutoMapper;
using Contracts.AllModels.MealsModels;
using DataCenter.MealsManagement;

namespace DataCenter.MealManagement
{
    public class MealRepository : IMealRepositoryService
    {
        private readonly static List<Meal> _Meal = new();
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public MealRepository(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public MealModel CreateObjectInDataBase(MealModel inputFromDeveloper)
        {
            var mappingToInsert = _mapper.Map<MealModel, Meal>(inputFromDeveloper);

            _context.Meals.Add(mappingToInsert);

            _context.SaveChanges();

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
