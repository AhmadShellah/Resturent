using DataCenter.Base;

namespace DataCenter.MealManagement
{
    public class Meal : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
