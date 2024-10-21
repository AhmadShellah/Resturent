using BusinessObjects.Models;
using DataAccess.Repositories;
using BusinessObjects.Interfaces;

namespace BusinessLogic
{
    public class OrderService(IOrderRepository repository,
        IMealRepository mealRepository,
        IOrderMealRepository orderMealRepository,
        IOrderMealDetailsRepository orderMealDetailsRepository) : IOrderService
    {
        private readonly IOrderRepository _repository = repository ??
            throw new ArgumentNullException(nameof(repository));

        private readonly IMealRepository _mealRepository = mealRepository ??
            throw new ArgumentNullException(nameof(mealRepository));

        private readonly IOrderMealRepository _orderMealRepository = orderMealRepository ??
            throw new ArgumentNullException(nameof(orderMealRepository));

        private readonly IOrderMealDetailsRepository _orderMealDetailsRepository = orderMealDetailsRepository ??
            throw new ArgumentNullException(nameof(orderMealDetailsRepository));

        public async Task<OrderModel> CreateAsync(OrderModel model)
        {
            var mealIds = model.OrderMeals.Select(m => m.MealId).ToList();

            var allMeals = await _mealRepository.GetAllAsync(m => mealIds.Contains(m.Id));

            var existingIds = allMeals.Select(m => m.Id).ToList();

            var nonExistingIds = mealIds.Except(existingIds).ToList();

            if (nonExistingIds.Count != 0)
            {
                throw new KeyNotFoundException($"Meals with following Ids:\n" +
                    $"{string.Join("\n", nonExistingIds)}\n" +
                    $"not found !!");
            }

            var returnedOrderModel = await _repository.CreateAsync(model);

            var mealDictionary = allMeals.ToDictionary(m => m.Id, m => m);

            var orderMealTasks = model.OrderMeals.Select(async orderMealModel =>
                {
                    var meal = mealDictionary[orderMealModel.MealId];
                    var returnedOrderMealModel = await _orderMealRepository.CreateAsync(orderMealModel, returnedOrderModel.Id, false);

                    orderMealModel.Details.UnitPrice = meal.Price;

                    var details = await _orderMealDetailsRepository.CreateAsync(orderMealModel.Details, returnedOrderMealModel.Id, false);

                    returnedOrderMealModel.Details = details;

                    return returnedOrderMealModel;
                }
            ).ToList();

            var returnedOrderMeals = await Task.WhenAll(orderMealTasks);

            returnedOrderModel.OrderMeals = [.. returnedOrderMeals];

            await _repository.SaveChanges();

            return returnedOrderModel;
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()  
        {
            return await repository.GetAllAsync();
        }

        public async Task<OrderModel> GetByIdAsync(Guid id) 
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _orderMealDetailsRepository.RemoveRangeAsync(id);

            await _orderMealRepository.RemoveAsync(om => om.OrderId == id);

            await _repository.RemoveAsync(id);

            await _repository.SaveChanges();
        }

        public async Task EditAsync(OrderModel editOrder)
        {
            await _repository.EditAsync(editOrder);

            var allOrderMeals = await _orderMealRepository.GetAllAsync(om => om.OrderId == editOrder.Id);

            var existingOrderMealIds = allOrderMeals.Select(om => om.MealId).ToList();

            var newOrderMealsIds = editOrder.OrderMeals.Select(om => om.MealId).ToList();

            var orderMealsToRemove = allOrderMeals.Where(om => !newOrderMealsIds.Contains(om.MealId))
                                                  .Select(om => om.Id)
                                                  .ToList();

            await _orderMealRepository.RemoveAsync(om => orderMealsToRemove.Contains(om.Id));

            var orderMealsToUpdate = editOrder.OrderMeals.Where(om => existingOrderMealIds.Contains(om.MealId)).ToList();

            foreach (var orderMeal in orderMealsToUpdate)
            {
                orderMeal.OrderId = editOrder.Id;
                var updatedOrderMeal = await _orderMealRepository.EditAsync(orderMeal);

                await _orderMealDetailsRepository.EditAsync(orderMeal.Details, updatedOrderMeal.Id);
            }

            var orderMealsToAdd = editOrder.OrderMeals.Where(om => !existingOrderMealIds.Contains(om.MealId)).ToList();

            var idsToAdd = orderMealsToAdd.Select(om => om.MealId).ToList();

            var meals = await _mealRepository.GetAllAsync(m => idsToAdd.Contains(m.Id));

            var mealsDictionary = meals.ToDictionary(m => m.Id, m => m);

            foreach (var orderMeal in orderMealsToAdd)
            {
                var meal = mealsDictionary[orderMeal.MealId];

                var returnedOrderMeal = await _orderMealRepository.CreateAsync(orderMeal, editOrder.Id, false);

                orderMeal.Details.UnitPrice = meal.Price;

                var details = await _orderMealDetailsRepository.CreateAsync(orderMeal.Details, returnedOrderMeal.Id, false);
            }

            await _repository.SaveChanges();
        }
    }
}