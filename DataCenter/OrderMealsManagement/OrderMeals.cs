using DataCenter.Base;
using DataCenter.MealManagement;
using DataCenter.OrderManagement;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataCenter.OrderMealsManagement
{
    public class OrderMeal : BaseEntity
    {
        [ForeignKey(nameof(Order))]
        public required Guid OrderId { get; set; }
        public required Order Order { get; set; }

        [ForeignKey(nameof(Meal))]
        public required Guid MealId { get; set; }
        public required Meal Meal { get; set; }

        public OrderMealDetails OrderMealDetails { get; set; } = null!;
    }


}
