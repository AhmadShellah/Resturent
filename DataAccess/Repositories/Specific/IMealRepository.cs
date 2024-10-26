using BusinessObjects.Models;
using DataAccess.Entities;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Specific
{
    public interface IMealRepository
    {
        Task<MealModel> CreateAsync(MealModel model, bool? saving = false);
        Task<MealModel> EditAsync(MealModel model);
        Task<IEnumerable<MealModel>> GetAllAsync(Expression<Func<Meal, bool>> filter);
        Task<IEnumerable<MealModel>> GetAllAsync();
        Task<MealModel> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id, bool? saving = false);
    }
}