namespace BusinessObjects.Models
{
    public class OrderMealModel
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid MealId { get; set; }
        public OrderMealDetailsModel Details { get; set; }
        public decimal TotalPrice 
        { 
            get => Details?.Quantity * Details?.UnitPrice ?? 0;  
        }
    }
}