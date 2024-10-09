using AutoMapper;
using Contracts.AllModels.MealsModels;
using DataCenter.MealManagement;

namespace DataCenter.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Meal, MealModel>();
            CreateMap<MealModel, Meal>()
                .ForMember(s => s.Id, c => c.Ignore());
        }
    }
}
