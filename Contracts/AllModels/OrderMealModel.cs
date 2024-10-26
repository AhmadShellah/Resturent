using Contracts.AllModels.MealsModels;

namespace Contracts.AllModels
{
    public class OrderMealModel
    {
        public Guid OrderId { get; set; }
        public OrderModel Order { get; set; }

        public Guid MealId { get; set; }
        public MealModel Meal { get; set; }

    }
}
