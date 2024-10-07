using BusinessObjects.Dtos.OrderMeal;

namespace BusinessObjects.Dtos.Order
{
    public class EditOrderDto
    {
        public Guid Id { get; set; }
        public required string OrderNumber { get; set; }
        public List<EditOrderMealDto> OrderMeals { get; set; }
    }
}
