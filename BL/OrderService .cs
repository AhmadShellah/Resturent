using AutoMapper;
using Contracts.AllModels.OredrsModels;
using Contracts.InterFacses;
using DataCenter.MealManagement;
using DataCenter.OrderManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepositoryService _orderRepository;
        private readonly IMapper _mapper;
        private readonly IMealService _mealService;

        public OrderService(IOrderRepositoryService orderRepository, IMapper mapper , IMealService mealService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _mealService = mealService;
        }

        public async Task<OrderModel> CreateOrder(OrderModel orderModel)
        {

            var meals = _mealService.GetMealService();

            foreach (var meal in orderModel.Meals)
            {
                var mealDetails = meals.FirstOrDefault(s=> s.Id == meal.MealId);

                meal.OrderMealDetails.UnitPrice = mealDetails.Price; 
            }

            var createdOrder = await _orderRepository.CreateOrder(orderModel);

            
            return createdOrder;
        }
        public async Task<IEnumerable<OrderModel>> GetOrders(Guid? id = null)
        {
            return  await _orderRepository.GetOrders(id);
        }

        //public OrderModel EditOrder(OrderModel updatedOrderModel)
        //{
        //    // Validate the updatedOrderModel here
        //    return _orderRepository.EditOrder(updatedOrderModel);
        //}

        //public bool DeleteOrder(Guid id)
        //{
        //    return _orderRepository.DeleteOrder(id);
        //}
    }
}
