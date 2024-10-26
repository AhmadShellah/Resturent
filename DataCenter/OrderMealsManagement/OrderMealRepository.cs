using AutoMapper;
using Contracts.AllModels;
using DataCenter.GenricRepo;
using Microsoft.EntityFrameworkCore;

namespace DataCenter.OrderMealsManagement
{
    public class OrderMealRepository
    {
        private readonly IMapper _mapper;
        private readonly IGetRepository<OrderMeal> _basicRepo;

        public OrderMealRepository(IGetRepository<OrderMeal> basicRepo, IMapper mapper)
        {
            _basicRepo = basicRepo;
            _mapper = mapper;
        }



        public async Task<IEnumerable<OrderMealModel>> GetAll()
        {
            var resultFromDataBase = _basicRepo.GetIQueryable(filter: null,
                includes: s =>
                s.Include(c => c.Order).Include(c => c.Meal))
                .AsEnumerable();

            var mapping = _mapper.Map<IEnumerable<OrderMealModel>>(resultFromDataBase);

            return mapping;
        }


    }
}
