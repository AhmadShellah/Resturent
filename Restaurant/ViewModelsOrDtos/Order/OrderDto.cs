
namespace Restaurant.ViewModelsOrDtos.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }

        public DateTime DueDate { get; set; }

        public List<OredrMealDto> Meals { get; set; }
    }
}
