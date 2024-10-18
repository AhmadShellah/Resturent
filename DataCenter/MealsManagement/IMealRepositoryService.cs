using Contracts.AllModels.MealsModels;
using System.Collections.Generic;

namespace DataCenter.MealsManagement
{
    public interface IMealRepositoryService
    {
        // Create a new meal
        MealModel CreateObjectInDataBase(MealModel inputFromDeveloper);

        // Get meals (all or by ID)
        IEnumerable<MealModel> GetMeals(Guid? id = null);

        // Edit an existing meal
        MealModel EditMeal(MealModel updatedMealModel);

        // Delete a meal by ID
        bool DeleteMeal(Guid id);
    }
}
