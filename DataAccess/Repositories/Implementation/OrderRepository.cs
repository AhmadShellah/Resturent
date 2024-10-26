using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Entities;
using DataAccess.Repositories.Generic;
using DataAccess.Repositories.Specific;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Implementation
{
    public class OrderRepository(ApplicationDbContext context, 
        IMapper mapper, 
        IGetRepository<Order> getRepository,
        ICreateRepository<Order> createRepository,
        IRemoveRepository<Order> removeRepository) : IOrderRepository
    {
        private readonly ApplicationDbContext _context = context;

        private readonly IMapper _mapper = mapper;

        private readonly IGetRepository<Order> _getRepository = getRepository;

        private readonly ICreateRepository<Order> _createRepository = createRepository;

        private readonly IRemoveRepository<Order> _removeRepository = removeRepository;

        public async Task<OrderModel> CreateAsync(OrderModel model, bool? saving = false)
        {
            var entity = _mapper.Map<Order>(model);

            await _createRepository.CreateAsync(entity, saving);

            return _mapper.Map<OrderModel>(entity);
        }

        public async Task<OrderModel> GetByIdAsync(Guid id)
        {
            var query = _getRepository.GetIQueryableAsync();

            var result = (await IncludeSubEntities(query)).FirstOrDefault(m => m.Id == id) ??
                        throw new KeyNotFoundException($"Order with id: {id} not found !!");

            return _mapper.Map<OrderModel>(result);
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            var query = _getRepository.GetIQueryableAsync();

            IEnumerable<Order> result = await IncludeSubEntities(query);

            return _mapper.Map<IEnumerable<OrderModel>>(result);
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync(Expression<Func<Order, bool>> filter)
        {
            var query = _getRepository.GetIQueryableAsync(filter);

            IEnumerable<Order> result = await IncludeSubEntities(query);

            return _mapper.Map<IEnumerable<OrderModel>>(result);
        }

        private static async Task<IEnumerable<Order>> IncludeSubEntities(IQueryable<Order> query)
        {
            return await query.Include(o => o.OrderMeals.Where(om => om.IsDeleted != true))
                .ThenInclude(o => o.Details)
                .ToListAsync();
        }

        public async Task RemoveAsync(Guid id, bool? saving = false)
        {
            await _removeRepository.RemoveAsync(id, saving);
        }

        public async Task EditAsync(OrderModel editOrder, bool? saving = false)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == editOrder.Id && !o.IsDeleted) ??
                        throw new KeyNotFoundException($"Order with id: {editOrder.Id} not found !!");

            order.OrderNumber = editOrder.OrderNumber;

            if (saving == true)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}