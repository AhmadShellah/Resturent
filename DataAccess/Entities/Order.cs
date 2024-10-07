namespace DataAccess.Entities
{
    public class Order: BaseEntity
    {
        public required string OrderNumber { get; set; }

        public ICollection<OrderMeal> OrderMeals { get; set; } = [];
    }
}
