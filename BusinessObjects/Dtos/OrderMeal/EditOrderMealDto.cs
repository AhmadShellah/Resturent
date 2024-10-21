using BusinessObjects.Dtos.OrderMealDetails;

namespace BusinessObjects.Dtos.OrderMeal
{
    public class EditOrderMealDto
    {
        public Guid MealId { get; set; }
        public EditOrderMealDetailsDto Details { get; set; }
    }
}
