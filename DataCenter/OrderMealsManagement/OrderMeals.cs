using DataCenter.Base;
using DataCenter.MealManagement;
using DataCenter.OrderManagement;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataCenter.OrderMealsManagement
{
    public class OrderMeal : BaseEntity
    {
        public required Guid OrderId { get; set; }
        public required Order Order { get; set; }

        public required Guid MealId { get; set; }
        public required Meal Meal { get; set; }

        public Guid OrderMealDetailsId { get; set; }
        public OrderMealDetails OrderMealDetails { get; set; } = null!;
    }


}
