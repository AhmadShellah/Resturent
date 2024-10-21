namespace DataAccess.Entities
{
    public class OrderMealDetails : BaseEntity
    {
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public Guid OrderMealId { get; set; }
        public OrderMeal OrderMeal { get; set; } = null!;
    }
}
