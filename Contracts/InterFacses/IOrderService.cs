using Contracts.AllModels;

namespace Contracts.InterFacses
{
    public interface IOrderService
    {
        Task<OrderModel> GetByIdAsync(Guid id);

        public Task<OrderModel> CreateFromEndUser(OrderModel inputFromEndUser);

    }
}
