

namespace BusinessObjects.Models.Meals
{
    public class MealsModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public double Weight { get; set; }

        public decimal Price { get; set; }

        public decimal Calories { get; set; }

        public int Code { get; set; }
    }
}
