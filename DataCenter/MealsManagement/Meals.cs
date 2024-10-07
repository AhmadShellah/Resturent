using DataCenter.Base;

namespace DataCenter.MealsManagement
{
    public class Meals : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; } 
    }
}
