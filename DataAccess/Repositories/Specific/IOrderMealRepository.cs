using BusinessObjects.Models;
using DataAccess.Entities;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Specific
{
    public interface IOrderMealRepository
    {
        Task<OrderMealModel> CreateAsync(OrderMealModel model, Guid orderId, bool? saving = false);
        Task<OrderMealModel> EditAsync(OrderMealModel model);
        Task<IEnumerable<OrderMealModel>> GetAllAsync(Expression<Func<OrderMeal, bool>> filter);
        Task<IEnumerable<OrderMealModel>> GetAllAsync();
        Task RemoveAsync(Expression<Func<OrderMeal, bool>> type, bool? saving = false);
    }
}