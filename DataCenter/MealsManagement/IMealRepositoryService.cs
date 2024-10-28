using Contracts.AllModels.MealsModels;

namespace DataCenter.MealsManagement
{
    public interface IMealRepositoryService
    {
        // Create a new meal
        public Task<MealModel> Create(MealModel inputFromDeveloper);

        // Get meals (all or by ID)
        public Task<IEnumerable<MealModel>> GetMeals();

        public Task<MealModel> GetById(Guid id);

        // Edit an existing meal
        public Task<MealModel> EditMeal(MealModel updatedMealModel);

        // Delete a meal by ID
        public Task<bool> DeleteMeal(Guid id);
    }
}
