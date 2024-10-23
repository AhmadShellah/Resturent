using Contracts.AllModels;

namespace DataCenter.OrderManagement
{
    public interface IOrderRepo
    {
        public Task<OrderModel> GetByIdAsync(Guid id);

        public Task<OrderModel> CreateFromUser(OrderModel inputFromUser);
    }
}
