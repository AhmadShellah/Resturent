namespace DataAccess.Entities
{
    public class Meal: BaseEntity
    {
        public required string Name { get; set; }
        public required string Details { get; set; }
        public required string MealCode { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public int Calories { get; set; }
    }
}
