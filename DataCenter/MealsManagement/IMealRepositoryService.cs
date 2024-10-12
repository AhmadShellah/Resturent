using Contracts.AllModels.MealsModels;

namespace DataCenter.MealsManagement
{
    public interface IMealRepositoryService
    {
        MealModel CreateObjectInDataBase(MealModel inputFromDeveloper);
    }
}
