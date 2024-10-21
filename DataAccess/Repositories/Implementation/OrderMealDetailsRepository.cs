using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation
{
    public class OrderMealDetailsRepository(ApplicationDbContext context, IMapper mapper) : IOrderMealDetailsRepository
    {
        private readonly ApplicationDbContext _context = context ??
            throw new ArgumentNullException(nameof(context));

        private readonly IMapper _mapper = mapper ?? 
            throw new ArgumentNullException(nameof(mapper));

        public async Task<OrderMealDetailsModel> CreateAsync(OrderMealDetailsModel model, Guid orderMealId, bool saving)
        {
            var entity = _mapper.Map<OrderMealDetails>(model);

            entity.OrderMealId = orderMealId;

            await _context.OrderMealDetails.AddAsync(entity);

            if (saving)
            {
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<OrderMealDetailsModel>(entity);
        }

        public async Task EditAsync(OrderMealDetailsModel details, Guid orderMealId)
        {
            var entity = await _context.OrderMealDetails.FirstOrDefaultAsync(d => d.OrderMealId == orderMealId) ?? 
                throw new KeyNotFoundException($"Order meal with id: {orderMealId} not found !!");

            entity.Quantity = details.Quantity;
        }

        public async Task<IEnumerable<OrderMealDetailsModel>> GetAllAsync(Predicate<OrderMealDetails>? filter)
        {
            return await _context.OrderMealDetails.Where(omd => (filter == null || filter(omd)) && !omd.IsDeleted)
                .Select(omd => _mapper.Map<OrderMealDetailsModel>(omd))
                .ToListAsync();
        }

        public async Task RemoveRangeAsync(Guid orderId)
        {
            var list = await _context.OrderMealDetails.Where(d => d.OrderMeal.OrderId == orderId && !d.IsDeleted)
                .ToListAsync();

            list.ForEach(d => d.SetIsDeleted());
        }
    }
}
