using BusinessObjects.Dtos.OrderMealDetails;

namespace BusinessObjects.Dtos.OrderMeal
{
    public class CreateOrderMealDto
    {
        public Guid MealId { get; set; }
        public CreateOrderMealDetailsDto Details { get; set; }
    }
}
