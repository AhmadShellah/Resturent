using BusinessObjects.Models;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class OrderRepository
    {
        private readonly static List<Order> orders = [];

        public async Task<OrderModel> CreateAsync(OrderModel model)
        {
            var entity = Mapper.GetEntity(model);

            orders.Add(entity);

            return Mapper.GetModel(entity);
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            return orders.Where(o => !o.IsDeleted)
                .Select(o => Mapper.GetModel(o))
                .ToList();
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (order is null)
            {
                return false;
            }
            else
            {
                order.SetIsDeleted();

                return true;
            }
        }

        public async Task<OrderModel> GetByIdAsync(Guid id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            if (order is null)
            {
                return null;
            }
            else
            {
                return Mapper.GetModel(order);
            }
        }

        public async Task<bool> EditAsync(OrderModel editOrder)
        {
            var order = orders.FirstOrDefault(o => o.Id == editOrder.Id && !o.IsDeleted);

            if(order is null)
            {
                return false;
            }
            else
            {
                order.OrderNumber = editOrder.OrderNumber;
                order.OrderMeals = editOrder.OrderMeals.Select(om => Mapper.GetEntity(om)).ToList();

                return true;
            }
        }
    }
}
