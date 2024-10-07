using BusinessObjects.Dtos.Order;
using BusinessObjects.Models;
using DataAccess.Repositories;

namespace BusinessLogic
{
    public class OrderService
    {
        private readonly OrderRepository repository;

        public OrderService()
        {
            repository = new OrderRepository();
        }

        public async Task<OrderModel> CreateAsync(OrderModel model)
        {
            var returnedModel = await repository.CreateAsync(model);

            returnedModel.OrderMeals.ForEach(meal => meal.TotalPrice = meal.Quantity * meal.UnitPrice);

            returnedModel.TotalPrice = returnedModel.OrderMeals.Sum(m => m.TotalPrice);

            return returnedModel;
        }

        public async Task<bool> EditAsync(OrderModel editOrder)
        {
            return await repository.EditAsync(editOrder);
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            var orderModelList = await repository.GetAllAsync();

            foreach (var order in orderModelList)
            {
                order.OrderMeals.ForEach(meal => meal.TotalPrice = meal.Quantity * meal.UnitPrice);

                order.TotalPrice = order.OrderMeals.Sum(m => m.TotalPrice);
            }

            return orderModelList;
        }

        public async Task<OrderModel?> GetByIdAsync(Guid id)
        {
            var returnedModel = await repository.GetByIdAsync(id);
            if(returnedModel is null)
            {
                return null;
            }
            else
            {
                returnedModel.OrderMeals.ForEach(meal => meal.TotalPrice = meal.Quantity * meal.UnitPrice);
                returnedModel.TotalPrice = returnedModel.OrderMeals.Sum(m => m.TotalPrice);
                return returnedModel;
            }
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            return await repository.RemoveAsync(id);
        }
    }
}
