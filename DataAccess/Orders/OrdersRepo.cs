using BusinessObjects.Models.Orders;
using BusinessObjects.Models.Meals;
using DataAccess.Meals;
using DataAccess.OrderMeal;
using BusinessObjects.Models.OrderMeal;

namespace DataAccess.Orders
{
    public class OrdersRepo
    {

        private readonly static List<OrdersEntity> _orders = new();

        public OrdersModel Create(OrdersModel inputFromUser)
        {
            // Convert OrderMealModel to OrderMealEntity
            var mealsEntities = inputFromUser.Meals.Select(meal => new OrderMealEntity
            {
                MealId = meal.MealId,
                OrderId = inputFromUser.Id,
                Quantity = meal.Quantity,
                UnitePrice = meal.UnitePrice
            }).ToList();

            
            var total = inputFromUser.Total;
            var mealsCount = inputFromUser.MealsCount;

            
            var modelToEntity = new OrdersEntity()
            {
                Id = inputFromUser.Id,
                Meals = mealsEntities, 
                OrderNum = inputFromUser.OrderNum,
                OrderDate = inputFromUser.OrderDate,
            };

            
            _orders.Add(modelToEntity);

            
            return new OrdersModel
            {
                Id = inputFromUser.Id,
                OrderNum = inputFromUser.OrderNum,
                OrderDate = inputFromUser.OrderDate,
                Total = total,
                MealsCount = mealsCount,
                Meals = inputFromUser.Meals 
            };
        }



        public List<OrdersModel> GetAll()
        {
            var result = _orders.Where(a => a.IsDeleted != true).Select(order => new OrdersModel()
            {
                Id = order.Id,
                OrderNum = order.OrderNum,
                OrderDate = order.OrderDate,
                MealsCount = order.Meals.Sum(m => m.Quantity), 
                Meals = order.Meals.Select(meal => new OrderMealModel()
                {
                    MealId = meal.MealId,
                    OrderId = meal.OrderId,
                    Quantity = meal.Quantity,
                    UnitePrice = meal.UnitePrice
                }).ToList(),
                Total = order.Meals.Sum(meal => meal.UnitePrice) 
            }).ToList();

            return result;

        }


        public OrdersModel GetById(Guid IdFromUser)
        {
            var result = _orders.Where(a => a.IsDeleted != true && a.Id == IdFromUser).Select(order => new OrdersModel()
            {
                Id = order.Id,
                OrderNum = order.OrderNum,
                OrderDate = order.OrderDate,
                MealsCount = order.Meals.Sum(m => m.Quantity),
                Meals = order.Meals.Select(meal => new OrderMealModel()
                {
                    MealId = meal.MealId,
                    OrderId = meal.OrderId,
                    Quantity = meal.Quantity,
                    UnitePrice = meal.UnitePrice
                }).ToList(),
                Total = order.Meals.Sum(meal => meal.UnitePrice)
            }).FirstOrDefault();

            return result;

        }


        public OrdersModel Edit(OrdersModel inputFromUser)
        {
            // Find the existing order by Id
            var existingOrder = _orders.FirstOrDefault(o => o.Id == inputFromUser.Id);

            if (existingOrder == null)
            {
                // Handle case where the order is not found
                throw new Exception("Order not found.");
            }

            // Update the existing order's meals
            existingOrder.Meals = inputFromUser.Meals.Select(meal => new OrderMealEntity
            {
                MealId = meal.MealId,
                OrderId = inputFromUser.Id,
                Quantity = meal.Quantity,
                UnitePrice = meal.UnitePrice
            }).ToList();


            // Return the updated model
            return new OrdersModel
            {
                Id = inputFromUser.Id,
                OrderNum = inputFromUser.OrderNum,
                OrderDate = inputFromUser.OrderDate,
                Total = inputFromUser.Total,
                MealsCount = inputFromUser.MealsCount,
                Meals = inputFromUser.Meals
            };
        }


        public bool Delete(Guid inputId)
        {
            
            var order = _orders.FirstOrDefault(o => o.Id == inputId);
            if (order != null && order.IsDeleted!=true)
            {
                
                order.SetIsDeleted();

                return true; 
            }

            return false; 
        }








    }
}
