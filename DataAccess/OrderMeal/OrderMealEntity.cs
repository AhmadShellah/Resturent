
namespace DataAccess.OrderMeal
{
    public class OrderMealEntity
    {
        public Guid MealId { get; set; }

        public Guid OrderId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitePrice { get; set; }


    }
}
