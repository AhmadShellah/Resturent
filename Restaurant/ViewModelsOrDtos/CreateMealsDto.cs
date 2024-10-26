using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModelsOrDtos
{
    public class CreateMealsDto
    {
        public string Name { get; set; }

        [Range(1, 1000)]
        public decimal Price { get; set; }
    }
}
