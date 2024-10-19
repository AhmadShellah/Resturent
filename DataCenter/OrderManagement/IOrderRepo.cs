using Contracts.AllModels;

namespace DataCenter.OrderManagement
{
    public interface IOrderRepo
    {
        public Task<OrderModel> CreateFromUser(OrderModel inputFromUser);
    }
}
