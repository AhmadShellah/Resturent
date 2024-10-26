using BusinessObjects.Models;
using DataAccess.Entities;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Specific
{
    public interface IOrderMealDetailsRepository
    {
        Task<OrderMealDetailsModel> CreateAsync(OrderMealDetailsModel model, Guid orderMealId, bool saving);
        Task EditAsync(OrderMealDetailsModel details, Guid orderMealId);
        Task<IEnumerable<OrderMealDetailsModel>> GetAllAsync(Expression<Func<OrderMealDetails, bool>> filter);
        Task<IEnumerable<OrderMealDetailsModel>> GetAllAsync();
        Task RemoveRangeAsync(Expression<Func<OrderMealDetails, bool>> filter, bool? saving = false);
    }
}