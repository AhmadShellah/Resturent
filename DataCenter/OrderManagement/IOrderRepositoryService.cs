using Contracts.AllModels.OredrsModels;

namespace Contracts.InterFacses
{
    public interface IOrderRepositoryService
    {
        public Task<OrderModel> CreateOrder(OrderModel orderModel);
        public Task<IEnumerable<OrderModel>> GetOrders();

        public Task<OrderModel> GetOrderById(Guid id);

        //OrderModel EditOrder(OrderModel updatedOrderModel);
        public Task<bool> DeleteOrder(Guid id);

    }
}