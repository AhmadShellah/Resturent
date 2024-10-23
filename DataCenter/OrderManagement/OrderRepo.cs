using AutoMapper;
using Contracts.AllModels;
using DataCenter.GenricRepo;
using Microsoft.EntityFrameworkCore;

namespace DataCenter.OrderManagement
{
    public class OrderRepo : IOrderRepo
    {
        private readonly IMapper _mapper;
        private readonly IBasicRepo<Order> _basicRepo;
        private readonly ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context, IMapper mapper, IBasicRepo<Order> basicRepo)
        {
            _context = context;
            _mapper = mapper;
            _basicRepo = basicRepo;
        }

        //public async Task<OrderModel> GetByIdAsync(Guid id)
        //{
        //    var result = await _basicRepo.GetByIdAsync(id);

        //    var mapping = _mapper.Map<OrderModel>(result);

        //    return mapping;
        //}

        public async Task<OrderModel> GetByIdAsync(Guid id)
        {
            var result = await _basicRepo.GetIQueryableAsync();

            var finalResult = await result.FirstOrDefaultAsync(s=> s.Id == id);

            var mapping = _mapper.Map<OrderModel>(finalResult);

            return mapping;
        }


        public async Task<List<OrderModel>> GetByDueDateAsync(DateTime dueDate)
        {
            var result = await _basicRepo.GetListAsync(s => s.DueDate.Date == dueDate.Date);

            var mapping = _mapper.Map<List<OrderModel>>(result);

            return mapping;
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
