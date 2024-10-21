using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Entities;

namespace DataAccess.Mapping
{
    public class OrderMealProfile : Profile
    {
        public OrderMealProfile()
        {
            CreateMap<OrderMeal, OrderMealModel>();

            CreateMap<OrderMealModel, OrderMeal>()
                .ForMember(dest => dest.Details, opt => opt.Ignore());
        }
    }
}