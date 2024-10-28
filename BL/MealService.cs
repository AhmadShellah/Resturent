using AutoMapper;
using Contracts.AllModels.MealsModels;
using Contracts.InterFacses;
using DataCenter.MealsManagement;

namespace Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepositoryService _mealsRepository;

        public MealService( IMealRepositoryService mealsRepository)
        {
            _mealsRepository = mealsRepository;
        }

        // Create a new meal
        public async Task<MealModel> CreateMealService(MealModel inputFromController)
        {
            ValidationFromInput(inputFromController);

            inputFromController.Description = "input From Service Or BL";

            var resultFromDataBase = await _mealsRepository.Create(inputFromController);

            return resultFromDataBase;
        }

        // Get meals (all or by ID)
        public async Task<IEnumerable<MealModel>> GetMeals()
        {
            var meals = await _mealsRepository.GetMeals();

            return meals.ToList();
        }

        public async Task<MealModel> GetMealById(Guid id)
        {
            var meal = await _mealsRepository.GetById(id);

            return meal;
        }

        // Edit an existing meal
        public async Task<MealModel> EditMealService(MealModel updatedMealModel)
        {
            ValidationFromInput(updatedMealModel); // Reuse validation logic before editing the meal

            var resultFromDataBase = await _mealsRepository.EditMeal(updatedMealModel);

            return resultFromDataBase;
        }

        // Delete a meal by ID
        public async Task<bool> DeleteMealService(Guid id)
        {
            var result = await _mealsRepository.DeleteMeal(id);

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
