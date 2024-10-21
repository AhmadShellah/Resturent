using BusinessObjects.Models;

namespace DataAccess.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderModel> CreateAsync(OrderModel model, bool? saving = false);
        Task EditAsync(OrderModel editOrder, bool? saving = false);
        Task<IEnumerable<OrderModel>> GetAllAsync();
        Task<OrderModel> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id, bool? saving = false);
        Task SaveChanges();
    }
}