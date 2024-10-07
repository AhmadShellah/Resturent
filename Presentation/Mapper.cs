using BusinessObjects.Dtos.Meal;
using BusinessObjects.Dtos.Order;
using BusinessObjects.Dtos.OrderMeal;
using BusinessObjects.Models;

namespace Presentation
{
    internal class Mapper
    {
        public static MealModel GetModel(CreateMealDto meal)
        {
            return new MealModel()
            {         
                Calories = meal.Calories,
                Details = meal.Details,
                MealCode = meal.MealCode,
                Name = meal.Name,
                Price = meal.Price,
                Weight = meal.Weight,
            };
        }

        public static MealDto GetDto(MealModel meal)
        {
            return new MealDto()
            {
                Id = meal.Id,
                Calories = meal.Calories,
                Details = meal.Details,
                MealCode = meal.MealCode,
                Name = meal.Name,
                Price = meal.Price,
                Weight = meal.Weight,
            };
        }

        public static MealModel GetModel(EditMealDto meal)
        {
            return new MealModel()
            {
                Id = meal.Id,
                Calories = meal.Calories,
                Details = meal.Details,
                MealCode = meal.MealCode,
                Name = meal.Name,
                Price = meal.Price,
                Weight = meal.Weight,
            };
        }


        public static OrderDto GetDto(OrderModel model)
        {
            return new OrderDto
            {
                Id = model.Id,
                OrderNumber = model.OrderNumber,
                TotalPrice = model.TotalPrice,
                OrderMeals = model.OrderMeals.Select(m => new OrderMealDto()
                {
                    MealId = m.MealId,
                    TotalPrice = m.TotalPrice,
                    UnitPrice = m.UnitPrice,
                    Quantity = m.Quantity
                }).ToList(),
            };
        }

        public static OrderModel GetModel(CreateOrderDto order)
        {
            return new OrderModel
            {
                OrderNumber = order.OrderNumber,
                OrderMeals = order.OrderMeals.Select(m => new OrderMealModel()
                {
                    MealId = m.MealId,
                    Quantity = m.Quantity,
                    UnitPrice = m.UnitPrice,
                }).ToList(),
            };
        }

        public static OrderModel GetModel(EditOrderDto order)
        {
            return new OrderModel
            {
                Id= order.Id,
                OrderNumber = order.OrderNumber,
                OrderMeals = order.OrderMeals.Select(m => new OrderMealModel()
                {
                    MealId = m.MealId,
                    UnitPrice = m.UnitPrice,
                    Quantity = m.Quantity,
                }).ToList(),
            };
        }
    }
}
