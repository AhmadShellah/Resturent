using AutoMapper;
using Contracts.AllModels;

namespace DataCenter.OrderManagement
{
    public class OrderRepo : IOrderRepo
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderModel> CreateFromUser(OrderModel inputFromUser)
        {
            var mapping = _mapper.Map<OrderModel, Order>(inputFromUser);

            await _context.Orders.AddAsync(mapping);

            await _context.SaveChangesAsync();

            return _mapper.Map<Order, OrderModel>(mapping);
        }
    }
}
