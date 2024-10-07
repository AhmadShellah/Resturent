using BusinessObjects.Dtos.Meal;
using BusinessObjects.Dtos.OrderMeal;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Dtos.Order
{
    public class CreateOrderDto
    {
        [Required(ErrorMessage = "Order number is required !!")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "Meals is required !!")]
        public List<CreateOrderMealDto> OrderMeals { get; set; }
    }
}
