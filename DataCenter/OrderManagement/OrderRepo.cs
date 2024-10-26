using AutoMapper;
using Contracts.AllModels;
using DataCenter.GenricRepo;
using Microsoft.EntityFrameworkCore;

namespace DataCenter.OrderManagement
{
    public class OrderRepo : IOrderRepo 
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _repository;

        public OrderRepo(IMapper mapper, IRepository<Order> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<OrderModel> GetByIdAsync(Guid id)
        {
            var result = await _repository.GetIQueryableAsync();

            var finalResult = await result.FirstOrDefaultAsync(s => s.Id == id);

            var mapping = _mapper.Map<OrderModel>(finalResult);

            return mapping;
        }

        public async Task<List<OrderModel>> GetByDueDateAsync(DateTime dueDate)
        {
            var result = await _repository.GetListAsync(s => s.DueDate.Date == dueDate.Date);

            var mapping = _mapper.Map<List<OrderModel>>(result);

            return mapping;
        }

        public async Task<OrderModel> CreateFromUser(OrderModel inputFromUser)
        {
            var mapping = _mapper.Map<OrderModel, Order>(inputFromUser);

            await _repository.CreateAsync(mapping, autoSave: inputFromUser.SaveChanges);

            return _mapper.Map<Order, OrderModel>(mapping);
        }
    }
}
