namespace BusinessObjects.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; }
        public List<OrderMealModel> OrderMeals { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
