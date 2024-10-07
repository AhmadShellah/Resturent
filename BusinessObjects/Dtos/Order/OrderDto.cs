using BusinessObjects.Dtos.Meal;
using BusinessObjects.Dtos.OrderMeal;

namespace BusinessObjects.Dtos.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public required string OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderMealDto> OrderMeals { get; set; }
    }
}
