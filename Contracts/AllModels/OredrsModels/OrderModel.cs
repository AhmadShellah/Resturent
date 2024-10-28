namespace Contracts.AllModels.OredrsModels
{
    public class OrderModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Number { get; set; }

        public DateTime DueDate { get; set; }

        public List<OrderMealModel> Meals { get; set; }
    }
}
