using BusinessObjects.Dtos.OrderMeal;
using BusinessObjects.Models;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class Mapper
    {

        public static Meal GetEntity(MealModel model)
        {
            return new Meal()
            {
                Details = model.Details,
                MealCode = model.MealCode,
                Name = model.Name,
                Calories = model.Calories,
                Price = model.Price,
                Weight = model.Weight,
            };
        }

        public static MealModel GetModel(Meal meal)
        {
            return new MealModel()
            {
                Id = meal.Id,
                Details = meal.Details,
                MealCode = meal.MealCode,
                Name = meal.Name,
                Calories = meal.Calories,
                Price = meal.Price,
                Weight = meal.Weight
            };
        }

        public static Order GetEntity(OrderModel order)
        {
            return new Order()
            {
                OrderNumber = order.OrderNumber,
                OrderMeals = order.OrderMeals.Select(m =>
                            new OrderMeal()
                            {
                                UnitPrice = m.UnitPrice,
                                MealID = m.MealId,
                                OrderID = order.Id,
                                Quantity = m.Quantity,      
                            }).ToList()
            };
        }

        public static OrderModel GetModel(Order order)
        {
            return new OrderModel()
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                OrderMeals = order.OrderMeals.Select(m => new OrderMealModel()
                {
                    MealId = m.MealID,
                    Quantity = m.Quantity,
                    UnitPrice = m.UnitPrice,
                }).ToList()
            };
        }

        public static OrderMeal GetEntity(OrderMealModel model)
        {
            return new OrderMeal()
            {
                MealID = model.MealId,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,

            };
        }
    }
}
