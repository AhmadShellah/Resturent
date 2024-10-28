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
        private readonly IRepository<Order> _Repository;

        public OrderRepository(IMapper mapper, IRepository<Order> repository)
        {
            _mapper = mapper;
            _Repository = repository;
        }

        public async Task<OrderModel> CreateOrder(OrderModel orderModel)
        {
            var order = _mapper.Map<OrderModel, Order>(orderModel);
            var result = await _Repository.CreateAsync(order, true);
            return _mapper.Map<Order, OrderModel>(result);
        }

        public async Task<IEnumerable<OrderModel>> GetOrders()
        {
            var orders = _Repository.GetIQueryable(filter: null,
                        includes: s =>
                        s.Include(c => c.Meals).ThenInclude(om => om.OrderMealDetails))
                        .AsEnumerable();

            return _mapper.Map<IEnumerable<OrderModel>>(orders);
        }

        public async Task<OrderModel> GetOrderById(Guid id)
        {
            var order = _Repository.GetIQueryable(filter: null,
                        includes: s =>
                        s.Include(c => c.Meals).ThenInclude(om => om.OrderMealDetails))
                        .FirstOrDefault(o => o.Id == id);

            var mapping = _mapper.Map<OrderModel>(order);

            return mapping;

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

        public async Task<bool> DeleteOrder(Guid id)
        {
            return await _Repository.RemoveAsync(id, true);
        }
    }
}
