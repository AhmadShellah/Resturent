using Contracts.AllModels.MealsModels;

namespace Contracts.InterFacses
{
    public interface IMealService
    {
        // Create a new meal
        public Task<MealModel> CreateMealService(MealModel inputFromController);

        // Get meals (all or by ID)
        public Task<IEnumerable<MealModel>> GetMeals();

        public Task<MealModel> GetMealById(Guid id);

        // Edit an existing meal
        public Task<MealModel> EditMealService(MealModel updatedMealModel);

        // Delete a meal by ID
        Task<bool> DeleteMealService(Guid id);
    }
}
