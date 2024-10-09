
using BusinessObjects.Models.OrderMeal;

namespace BusinessObjects.Models.Orders
{
    public class OrdersModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int OrderNum { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }

        public int MealsCount { get; set; }

        public List<OrderMealModel> Meals { get; set; }

    }
}
