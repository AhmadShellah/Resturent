namespace BusinessObjects.Models
{
    public class MealModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        public string MealCode { get; set; }

        public double Weight { get; set; }

        public decimal Price { get; set; }

        public int Calories { get; set; }
    }
}
