using Contracts.AllModels.OredrsModels;


namespace Contracts.InterFacses
{
    public interface IOrderService
    {
        OrderModel CreateOrder(OrderModel orderModel);
        IEnumerable<OrderModel> GetOrders(Guid? id = null);
        //OrderModel EditOrder(OrderModel updatedOrderModel);
        //bool DeleteOrder(Guid id);
    }
}
