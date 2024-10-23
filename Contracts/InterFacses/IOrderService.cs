using Contracts.AllModels;

namespace Contracts.InterFacses
{
    public interface IOrderService
    {
        Task<OrderModel> GetByIdAsync(Guid id);

        Task<List<OrderModel>> GetByDueDateAsync(DateTime dueDate);

        public Task<OrderModel> CreateFromEndUser(OrderModel inputFromEndUser);


    }
}
