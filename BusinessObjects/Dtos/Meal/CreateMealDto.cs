using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Dtos.Meal
{
    public class CreateMealDto
    {
        [Required(ErrorMessage = "Name is required !!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Details is required !!")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Meal code is required.")]
        public string MealCode { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Calories are required.")]
        public int Calories { get; set; }
    }
}
