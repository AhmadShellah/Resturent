using BusinessObjects.Models;
using DataAccess.Entities;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Specific
{
    public interface IOrderRepository
    {
        Task<OrderModel> CreateAsync(OrderModel model, bool? saving = false);
        Task EditAsync(OrderModel editOrder, bool? saving = false);
        Task<IEnumerable<OrderModel>> GetAllAsync();
        Task<IEnumerable<OrderModel>> GetAllAsync(Expression<Func<Order, bool>> filter);
        Task<OrderModel> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id, bool? saving = false);
        Task SaveChanges();
    }
}