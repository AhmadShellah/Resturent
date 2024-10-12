using AutoMapper;
using Contracts.AllModels.MealsModels;
using Contracts.InterFacses;
using DataCenter.MealManagement;
using DataCenter.MealsManagement;

namespace Services
{
    public class MealService : IMealService
    {
        private readonly IMapper _mapper;
        private readonly IMealRepositoryService _mealsRepository;

        public MealService(IMapper mapper, IMealRepositoryService mealsRepository)
        {
            _mapper = mapper;
            _mealsRepository = mealsRepository;
        }

        public MealModel CreateMealService(MealModel inputFromController)
        {
            ValidationFromInput(inputFromController);

            inputFromController.Description = "input From Service Or BL";

            var resultFromDataBase = _mealsRepository.CreateObjectInDataBase(inputFromController);

            return resultFromDataBase;
        }

        public MealModel Create(MealModel inputFromController)
        {
            ValidationFromInput(inputFromController);

            inputFromController.Description = "input From Service Or BL";

            var resultFromDataBase = _mealsRepository.CreateObjectInDataBase(inputFromController);

            return resultFromDataBase;
        }

        private static void ValidationFromInput(MealModel inputFromController)
        {
            //Cards If 
            if (inputFromController == null)
            {
                throw new Exception("The Object Is null");
            }

            if (string.IsNullOrWhiteSpace(inputFromController.Name))
            {
                throw new Exception("The Name Is null");
            }

            if (inputFromController.Price <= 0)
            {
                throw new Exception("The Price Less Than Zero");
            }
        }
    }
}
