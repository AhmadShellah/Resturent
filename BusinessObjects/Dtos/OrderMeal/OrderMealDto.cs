using BusinessObjects.Dtos.OrderMealDetails;

namespace BusinessObjects.Dtos.OrderMeal
{
    public class OrderMealDto
    {
        public Guid MealId { get; set; }
        public OrderMealDetailsDto Details { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
