

namespace BusinessObjects.Dtos.OrderMeal
{
    public class OrderMealDto
    {
        public Guid MealId { get; set; }

        public Guid OrderId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitePrice { get; set; }
    }
}
