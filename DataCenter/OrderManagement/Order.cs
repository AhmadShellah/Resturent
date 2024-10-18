using DataCenter.Base;
using DataCenter.OrderMealsManagement;

namespace DataCenter.OrderManagement
{
    public class Order : BaseEntity
    {
        public int Number { get; set; }

        public DateTime DueDate { get; set; }

        public List<OrderMeal> Meals { get; set; }
    }
}
