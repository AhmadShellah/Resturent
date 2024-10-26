using AutoMapper;
using Contracts.AllModels.MealsModels;
using DataCenter.MealManagement;

namespace DataCenter.AutoMapper
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<Meal, MealModel>();

            CreateMap<MealModel, Meal>()
                .ForMember(s => s.Id, c => c.Ignore())
                .ForMember(dest => dest.IsDeleted,
                src => src.MapFrom(src => src.Deleted));
        }
    }
}
