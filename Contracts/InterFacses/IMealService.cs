using Contracts.AllModels.MealsModels;
using System.Collections.Generic;

namespace Contracts.InterFacses
{
    public interface IMealService
    {
        // Create a new meal
        MealModel CreateMealService(MealModel inputFromController);

        // Get meals (all or by ID)
        IEnumerable<MealModel> GetMealService(Guid? id = null);

        // Edit an existing meal
        MealModel EditMealService(MealModel updatedMealModel);

        // Delete a meal by ID
        bool DeleteMealService(Guid id);
    }
}
