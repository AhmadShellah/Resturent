namespace Restaurant.ViewModelsOrDtos.Order
{
    public class OredrMealDto
    {
        public Guid Id { get; set; } // Id of the OrderMeal
        public Guid OrderId { get; set; } // Foreign key to Order
        public Guid MealId { get; set; } // Foreign key to Meal
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
