
using BusinessObjects.Dtos.OrderMeal;


namespace BusinessObjects.Dtos.Orders
{
    public class OrdersDto : BaseEntityDto
    {
        public int OrderNum { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }

        public int MealsCount { get; set; }

        public List<OrderMealDto> Meals { get; set; }
    }
}
