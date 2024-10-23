using Contracts.AllModels;
using Contracts.InterFacses;
using DataCenter.OrderManagement;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<OrderModel> GetByIdAsync(Guid id)
        {
            return await _orderRepo.GetByIdAsync(id);
        }

        public async Task<OrderModel> CreateFromEndUser(OrderModel inputFromEndUser)
        {
            inputFromEndUser.Number = new Random().Next(0, 100);
            inputFromEndUser.DueDate = inputFromEndUser.DueDate.Date;

            return await _orderRepo.CreateFromUser(inputFromEndUser);
        }

       
    }
}
