using DataCenter.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataCenter.OrderMealsManagement
{
    public class OrderMealDetails : BaseEntity
    {
        public int Qty { get; set; }

        public decimal UnitPrice { get; set; }


        [ForeignKey(nameof(OrderMeal))]
        public Guid OrderMealId { get; set; }
        public OrderMeal OrderMeal { get; set; }
    }
}
