using AutoMapper;
using Contracts.AllModels;
using Contracts.AllModels.MealsModels;
using Restaurant.ViewModelsOrDtos;

namespace Restaurant.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateMealsDto, MealModel>().ReverseMap();
            CreateMap<MealModel, MealsViewModelOrDto>().ReverseMap();

          
        }
    }
}
