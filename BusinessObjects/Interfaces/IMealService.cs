using BusinessObjects.Models;

namespace BusinessObjects.Interfaces
{
    public interface IMealService
    {
        Task<MealModel> CreateAsync(MealModel model);
        Task<MealModel> EditAsync(MealModel model);
        Task<IEnumerable<MealModel>> GetAllAsync();
        Task<MealModel> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
    }
}