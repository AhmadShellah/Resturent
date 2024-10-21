using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation
{
    public class OrderRepository(ApplicationDbContext context, IMapper mapper) : IOrderRepository
    {
        private readonly ApplicationDbContext _context = context ?? 
            throw new ArgumentNullException(nameof(context));

        private readonly IMapper _mapper = mapper ?? 
            throw new ArgumentNullException(nameof(mapper));

        public async Task<OrderModel> CreateAsync(OrderModel model, bool? saving = false)
        {
            var entity = _mapper.Map<Order>(model);

            await _context.Orders.AddAsync(entity);

            if (saving == true)
            {
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<OrderModel>(entity, opts =>
            {
                opts.Items["PartialMapping"] = true; 
            });
        }

        public async Task<OrderModel> GetByIdAsync(Guid id)
        {
            var order = await _context.Orders.Include(o => o.OrderMeals)
                                                .ThenInclude(o => o.Details)
                                             .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted) ??
                        throw new KeyNotFoundException($"Order with id: {id} not found !!");

            order.OrderMeals = order.OrderMeals.Where(om => !om.IsDeleted && !om.Details.IsDeleted).ToList();

            return _mapper.Map<OrderModel>(order);
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            var orders =  await _context.Orders.Where(o => !o.IsDeleted) 
                                 .Include(o => o.OrderMeals) 
                                     .ThenInclude(om => om.Details) 
                                 .ToListAsync();

            orders.ForEach(o =>
                o.OrderMeals = o.OrderMeals.Where(om => !om.IsDeleted && !om.Details.IsDeleted).ToList()
            );

            return _mapper.Map<IEnumerable<OrderModel>>(orders);
        }

        public async Task RemoveAsync(Guid id, bool? saving = false)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted) ??
                        throw new KeyNotFoundException($"Order with id: {id} not found !!");

            order.SetIsDeleted();

            if (saving == true)
            {
                await _context.SaveChangesAsync();
            }
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
