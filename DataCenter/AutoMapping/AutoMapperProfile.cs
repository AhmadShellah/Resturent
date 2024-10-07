using AutoMapper;
using Contracts.AllModels.MealsModels;
using DataCenter.MealsManagement;

namespace DataCenter.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Meals, MealModel>();
            CreateMap<MealModel, Meals>()
                .ForMember(s => s.Id, c => c.Ignore());
        }
    }
}
