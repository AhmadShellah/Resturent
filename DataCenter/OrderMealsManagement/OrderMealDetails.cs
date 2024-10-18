using DataCenter.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataCenter.OrderMealsManagement
{
    public class OrderMealDetails : BaseEntity
    {

        [ForeignKey(nameof(OrderMeal))]
        public Guid OrderMealId { get; set; }
        public OrderMeal OrderMeal { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }


    }
}
