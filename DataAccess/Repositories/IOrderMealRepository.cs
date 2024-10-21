using BusinessObjects.Models;
using DataAccess.Entities;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public interface IOrderMealRepository
    {
        Task<OrderMealModel> CreateAsync(OrderMealModel model, Guid orderId, bool saving);
        Task<OrderMealModel> EditAsync(OrderMealModel model);
        Task<IEnumerable<OrderMealModel>> GetAllAsync(Expression<Func<OrderMeal, bool>>? filter = null);
        Task RemoveAsync(Expression<Func<OrderMeal, bool>>? type = null, bool? saving = false);
    }
}