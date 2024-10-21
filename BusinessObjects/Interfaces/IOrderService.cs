using BusinessObjects.Models;

namespace BusinessObjects.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModel> CreateAsync(OrderModel model);
        Task EditAsync(OrderModel editOrder);
        Task<IEnumerable<OrderModel>> GetAllAsync();
        Task<OrderModel> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
    }
}