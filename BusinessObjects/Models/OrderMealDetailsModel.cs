namespace BusinessObjects.Models
{
    public class OrderMealDetailsModel
    {
        public Guid Id { get; set; }

        public Guid OrderMealId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
