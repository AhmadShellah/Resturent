using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Entities;

namespace DataAccess.Mapping
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<Meal, MealModel>()
                .ReverseMap();
        }
    }
}