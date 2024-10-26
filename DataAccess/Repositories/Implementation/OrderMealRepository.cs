using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Entities;
using DataAccess.Repositories.Generic;
using DataAccess.Repositories.Specific;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Implementation
{
    public class OrderMealRepository(ApplicationDbContext context, 
        IMapper mapper, 
        IGetRepository<OrderMeal> getRepository,
        ICreateRepository<OrderMeal> createRepository,
        IRemoveRepository<OrderMeal> removeRepository) : IOrderMealRepository
    {
        private readonly ApplicationDbContext _context = context;

        private readonly IMapper _mapper = mapper;

        private readonly IGetRepository<OrderMeal> _getRepository = getRepository;

        private readonly ICreateRepository<OrderMeal> _createRepository = createRepository;

        private readonly IRemoveRepository<OrderMeal> _removeRepository = removeRepository;

        public async Task<OrderMealModel> CreateAsync(OrderMealModel model, Guid orderId, bool? saving = false)
        {
            var entity = _mapper.Map<OrderMeal>(model);

            entity.OrderId = orderId;

            await _createRepository.CreateAsync(entity, saving);

            return _mapper.Map<OrderMealModel>(entity);
        }

        public async Task<OrderMealModel> EditAsync(OrderMealModel model)
        {
            var orderMeal = await _context.OrderMeals.FirstOrDefaultAsync(om => om.MealId == model.MealId && om.OrderId == model.OrderId && !om.IsDeleted) ??
                            throw new KeyNotFoundException($"Order meal with id: {model.Id} not found !!");

            return _mapper.Map<OrderMealModel>(orderMeal);
        }

        public async Task<IEnumerable<OrderMealModel>> GetAllAsync(Expression<Func<OrderMeal, bool>> filter)
        {
            var result = await _getRepository.GetAllAsync(filter);

            return _mapper.Map<IEnumerable<OrderMealModel>>(result);    
        }

        public async Task<IEnumerable<OrderMealModel>> GetAllAsync()
        {
            var result = await _getRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<OrderMealModel>>(result);
        }

        public async Task RemoveAsync(Expression<Func<OrderMeal, bool>> type, bool? saving = false)
        {
            await _removeRepository.RemoveRangeAsync(type, saving);
        }
    }
}
