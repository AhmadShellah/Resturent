using AutoMapper;
using BusinessObjects.Dtos.Meal;
using BusinessObjects.Models;

namespace Presentation.Mapping
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<CreateMealDto, MealModel>();
            CreateMap<EditMealDto, MealModel>();
            CreateMap<MealModel, MealDto>().ReverseMap();
        }
    }
}
