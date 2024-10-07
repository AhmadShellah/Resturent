namespace BusinessObjects.Dtos.OrderMeal
{
    public class CreateOrderMealDto
    {
        public Guid MealId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
