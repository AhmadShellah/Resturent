namespace Contracts.AllModels.OredrsModels
{
    public class OrderMealModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public Guid MealId { get; set; }

        public OrderMealDetailModel OrderMealDetails { get; set; } = null!;

    }
}
