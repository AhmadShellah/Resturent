using Contracts.AllModels.MealsModels;

namespace Contracts.InterFacses
{
    public interface IMealService
    {
        MealModel CreateMealService(MealModel inputFromController);
    }
}
