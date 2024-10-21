using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Implementation
{
    public class OrderMealRepository(ApplicationDbContext context, IMapper mapper) : IOrderMealRepository
    {
        private readonly ApplicationDbContext _context = context ??
            throw new ArgumentNullException(nameof(context));

        private readonly IMapper _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));

        public async Task<OrderMealModel> CreateAsync(OrderMealModel model, Guid orderId, bool saving)
        {
            var entity = _mapper.Map<OrderMeal>(model);

            entity.OrderId = orderId;

            await _context.OrderMeals.AddAsync(entity);

            if (saving)
            {
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<OrderMealModel>(entity);
        }

        public async Task<OrderMealModel> EditAsync(OrderMealModel model)
        {
            var orderMeal = await _context.OrderMeals.FirstOrDefaultAsync(om => om.MealId == model.MealId && om.OrderId == model.OrderId && !om.IsDeleted) ??
                            throw new KeyNotFoundException($"Order meal with id: {model.Id} not found !!");

            return _mapper.Map<OrderMealModel>(orderMeal);
        }

        public async Task<IEnumerable<OrderMealModel>> GetAllAsync(Expression<Func<OrderMeal, bool>>? filter = null)
        {
            return await _context.OrderMeals.Where(om => !om.IsDeleted)
                .Where(filter ?? (om => true))
                .Select(om => _mapper.Map<OrderMealModel>(om))
                .ToListAsync();
        }

        public async Task RemoveAsync(Expression<Func<OrderMeal, bool>>? type = null, bool? saving = false)
        {

            var entities = await _context.OrderMeals.Where(om => !om.IsDeleted)
                .Where(type ?? (om => true))
                .ToListAsync();

            entities.ForEach(om => om.SetIsDeleted());


            if (saving == true)
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}
