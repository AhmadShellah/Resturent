using DataCenter.Base;

namespace DataCenter.OrderManagement
{
    public class Order : BaseEntity
    {
        public int Number { get; set; }

        public DateTime DueDate { get; set; }
    }
}
