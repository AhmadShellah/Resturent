using BusinessObjects.Models;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IOrderMealDetailsRepository
    {
        Task<OrderMealDetailsModel> CreateAsync(OrderMealDetailsModel model, Guid orderMealId, bool saving);
        Task EditAsync(OrderMealDetailsModel details, Guid orderMealId);
        Task<IEnumerable<OrderMealDetailsModel>> GetAllAsync(Predicate<OrderMealDetails>? filter);
        Task RemoveRangeAsync(Guid orderId);
    }
}