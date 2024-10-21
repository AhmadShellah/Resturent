using BusinessObjects.Models;
using DataAccess.Entities;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public interface IMealRepository
    {
        Task<MealModel> CreateAsync(MealModel model);
        Task<MealModel> EditAsync(MealModel model);
        Task<IEnumerable<MealModel>> GetAllAsync(Expression<Func<Meal, bool>>? filter = null);
        Task<MealModel> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
    }
}