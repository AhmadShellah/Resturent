using AutoMapper;
using Contracts.AllModels.OredrsModels;
using Contracts.InterFacses;
using DataCenter.GenricRepo;
using Microsoft.EntityFrameworkCore;

namespace DataCenter.OrderManagement
{
    public class OrderRepository : IOrderRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly IBasicRepo<Order> _basicRepo;
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context, IMapper mapper, IBasicRepo<Order> basicRepo)
        {
            _context = context;
            _mapper = mapper;
            _basicRepo = basicRepo;
        }

        public OrderModel CreateOrder(OrderModel orderModel)
        {
            var order = _mapper.Map<OrderModel, Order>(orderModel);
            _context.Orders.Add(order);
            _context.SaveChanges();

            return _mapper.Map<Order, OrderModel>(order);
        }

        public async Task<IEnumerable<OrderModel>> GetOrders(Guid? id = null)
        {
            if (id.HasValue)
            {
                var orders = await _basicRepo.GetIQueryableAsync();
                orders = orders.Include(o => o.Meals).ThenInclude(om => om.OrderMealDetails);

                var order = orders.FirstOrDefault(o => o.Id == id.Value);

                return order != null
                    ? new List<OrderModel> { _mapper.Map<Order, OrderModel>(order) }
                    : new List<OrderModel>();
            }
            else
            {
                var orders = await _basicRepo.GetIQueryableAsync();
                orders = orders.Include(o => o.Meals).ThenInclude(om => om.OrderMealDetails);

                return _mapper.Map<IEnumerable<OrderModel>>(orders.ToList());
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
