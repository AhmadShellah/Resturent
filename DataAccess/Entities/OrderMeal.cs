namespace DataAccess.Entities
{
    public class OrderMeal: BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public Guid MealId { get; set; }
        public Meal Meal { get; set; } = null!;

        public OrderMealDetails Details { get; set; } = null!;
    }
}
