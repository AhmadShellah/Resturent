using Contracts.AllModels.OredrsModels;


namespace Contracts.InterFacses
{
    public interface IOrderService
    {
        public Task<OrderModel> CreateOrder(OrderModel orderModel);
        public Task<IEnumerable<OrderModel>> GetOrders();

        //OrderModel EditOrder(OrderModel updatedOrderModel);
        public Task<bool> DeleteOrder(Guid id);
    }
}
