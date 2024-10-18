using AutoMapper;
using Contracts.AllModels.MealsModels;
using Contracts.InterFacses;
using DataCenter.MealManagement;
using DataCenter.MealsManagement;
using System.Collections.Generic;

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

        // Create a new meal
        public MealModel CreateMealService(MealModel inputFromController)
        {
            ValidationFromInput(inputFromController);

            inputFromController.Description = "input From Service Or BL";

            var resultFromDataBase = _mealsRepository.CreateObjectInDataBase(inputFromController);

            return resultFromDataBase;
        }

        // Get meals (all or by ID)
        public IEnumerable<MealModel> GetMealService(Guid? id = null)
        {
            return _mealsRepository.GetMeals(id);
        }

        // Edit an existing meal
        public MealModel EditMealService(MealModel updatedMealModel)
        {
            ValidationFromInput(updatedMealModel); // Reuse validation logic before editing the meal

            var resultFromDataBase = _mealsRepository.EditMeal(updatedMealModel);

            if (resultFromDataBase == null)
            {
                throw new Exception("Meal not found");
            }

            return resultFromDataBase;
        }

        // Delete a meal by ID
        public bool DeleteMealService(Guid id)
        {
            var result = _mealsRepository.DeleteMeal(id);

            if (!result)
            {
                throw new Exception("Meal not found or could not be deleted");
            }

            return result;
        }

        // Input validation method
        private static void ValidationFromInput(MealModel inputFromController)
        {
            if (inputFromController == null)
            {
                throw new Exception("The Object Is null");
            }

            if (string.IsNullOrWhiteSpace(inputFromController.Name))
            {
                throw new Exception("The Name is null or empty");
            }

            if (inputFromController.Price <= 0)
            {
                throw new Exception("The Price must be greater than zero");
            }
        }
    }
}
