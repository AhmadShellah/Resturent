using AutoMapper;
using Contracts.AllModels.OredrsModels;
using Contracts.InterFacses;
using Microsoft.EntityFrameworkCore;

namespace DataCenter.OrderManagement
{
    public class OrderRepository : IOrderRepositoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OrderModel CreateOrder(OrderModel orderModel)
        {
            var order = _mapper.Map<OrderModel, Order>(orderModel);
            _context.Orders.Add(order);
            _context.SaveChanges();

            return _mapper.Map<Order, OrderModel>(order);
        }

        public IEnumerable<OrderModel> GetOrders(Guid? id = null)
        {
            if (id.HasValue)
            {
                var order = _context.Orders.Include(o => o.Meals).ThenInclude(om => om.OrderMealDetails)
                    .FirstOrDefault(o => o.Id == id.Value);
                return order != null
                    ? new List<OrderModel> { _mapper.Map<Order, OrderModel>(order) }
                    : new List<OrderModel>();
            }
            else
            {
                var orders = _context.Orders.Include(o => o.Meals).ThenInclude(om => om.OrderMealDetails).ToList();
                return _mapper.Map<IEnumerable<OrderModel>>(orders);
            }
        }

        //public OrderModel EditOrder(OrderModel updatedOrderModel)
        //{
        //    var order = _context.Orders.Include(o => o.Meals).FirstOrDefault(o => o.Id == updatedOrderModel.Id);
        //    if (order != null)
        //    {
        //        _mapper.Map(updatedOrderModel, order);
        //        _context.Entry(order).State = EntityState.Modified;
        //        _context.SaveChanges();
        //        return _mapper.Map<Order, OrderModel>(order);
        //    }
        //    return null;
        //}

        //public bool DeleteOrder(Guid id)
        //{
        //    var order = _context.Orders.Find(id);
        //    if (order != null)
        //    {
        //        _context.Orders.Remove(order);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}
    }
}
