
namespace BusinessObjects.Models.OrderMeal
{
    public class OrderMealModel
    {
        public Guid MealId { get; set; }

        public Guid OrderId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitePrice { get; set; }
    }
}
