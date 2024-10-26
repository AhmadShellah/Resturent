using AutoMapper;
using Contracts.AllModels.MealsModels;
using DataCenter.GenricRepo;
using DataCenter.MealsManagement;

namespace DataCenter.MealManagement
{
    public class MealRepository : IMealRepositoryService
    {
        private readonly static List<Meal> _Meal = new();
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IGetRepository<Meal> _basicRepo;

        public MealRepository(IMapper mapper, ApplicationDbContext context, IGetRepository<Meal> basicRepo)
        {
            _mapper = mapper;
            _context = context;
            _basicRepo = basicRepo;
        }

        public async Task<List<MealModel>> GetMealsList()
        {
            var result = await _basicRepo.GetListAsync(s => s.Description == "Ahmad");

            var mapping = _mapper.Map<List<MealModel>>(result);

            return mapping;
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
