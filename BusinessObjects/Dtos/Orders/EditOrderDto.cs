using BusinessObjects.Dtos.OrderMeal;

namespace BusinessObjects.Dtos.Orders
{
    public class EditOrderDto
    {
        public Guid Id { get; set; }

        public List<CreateOrderMealDto> Orders { get; set; }

    }
}
