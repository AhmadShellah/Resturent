using DataAccess.OrderMeal;


namespace DataAccess.Orders
{
    public class OrdersEntity : BaseEntity
    {

        public int OrderNum { get; set; }

        public DateTime OrderDate { get; set; }

        public ICollection<OrderMealEntity> Meals { get; set; }


    }
}
