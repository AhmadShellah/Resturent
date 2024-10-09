

namespace BusinessObjects.Dtos.Meals
{
    public class MealsDto : BaseEntityDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public double Weight { get; set; } 

        public decimal Price { get; set; }

        public decimal Calories { get; set; }

        public int Code { get; set; }
    }
}
