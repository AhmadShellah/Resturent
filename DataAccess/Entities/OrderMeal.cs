namespace DataAccess.Entities
{
    public class OrderMeal: BaseEntity
    {
        public Guid OrderID { get; set; }
        public Guid MealID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Order Order { get; set; }
        public Meal Meal { get; set; }
    }
}
