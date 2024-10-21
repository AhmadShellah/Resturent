using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Entities;

namespace DataAccess.Mapping
{
    public class OrderMealDetailsProfile : Profile
    {
        public OrderMealDetailsProfile()
        {
            CreateMap<OrderMealDetails, OrderMealDetailsModel>()
                .ReverseMap();
        }
    }
}