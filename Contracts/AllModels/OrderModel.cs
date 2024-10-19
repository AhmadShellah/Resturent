namespace Contracts.AllModels
{
    public class OrderModel
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public DateTime DueDate { get; set; }
    }
}
