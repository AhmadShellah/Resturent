using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Entities;
using DataAccess.Repositories.Generic;
using DataAccess.Repositories.Specific;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Implementation
{
    public class OrderMealDetailsRepository(ApplicationDbContext context, 
        IMapper mapper,
        IGetRepository<OrderMealDetails> getRepository,
        ICreateRepository<OrderMealDetails> createRepository,
        IRemoveRepository<OrderMealDetails> removeRepository) : IOrderMealDetailsRepository
    {
        private readonly ApplicationDbContext _context = context;

        private readonly IMapper _mapper = mapper;

        private readonly IGetRepository<OrderMealDetails> _getRepository = getRepository;

        private readonly ICreateRepository<OrderMealDetails> _createRepository = createRepository;

        private readonly IRemoveRepository<OrderMealDetails> _removeRepository = removeRepository;

        public async Task<OrderMealDetailsModel> CreateAsync(OrderMealDetailsModel model, Guid orderMealId, bool saving)
        {
            var entity = _mapper.Map<OrderMealDetails>(model);

            entity.OrderMealId = orderMealId;

            await _createRepository.CreateAsync(entity, saving);

            return _mapper.Map<OrderMealDetailsModel>(entity);
        }

        public async Task EditAsync(OrderMealDetailsModel details, Guid orderMealId)
        {
            var entity = await _context.OrderMealDetails.FirstOrDefaultAsync(d => d.OrderMealId == orderMealId) ?? 
                throw new KeyNotFoundException($"Order meal with id: {orderMealId} not found !!");

            entity.Quantity = details.Quantity;
        }

        public async Task<IEnumerable<OrderMealDetailsModel>> GetAllAsync(Expression<Func<OrderMealDetails, bool>> filter)
        {
            var result = await _getRepository.GetAllAsync(filter);

            return _mapper.Map<IEnumerable<OrderMealDetailsModel>>(result);
        }

        public async Task<IEnumerable<OrderMealDetailsModel>> GetAllAsync()
        {
            var result = await _getRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<OrderMealDetailsModel>>(result);
        }

        public async Task RemoveRangeAsync(Expression<Func<OrderMealDetails, bool>> filter, bool? saving = false)
        {
            await _removeRepository.RemoveRangeAsync(filter, saving);
        }
    }
}