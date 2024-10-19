using Contracts.AllModels;

namespace Contracts.InterFacses
{
    public interface IOrderService
    {
        public Task<OrderModel> CreateFromEndUser(OrderModel inputFromEndUser);

    }
}
