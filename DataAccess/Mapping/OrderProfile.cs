using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Entities;

namespace DataAccess.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderModel>();

            CreateMap<OrderModel, Order>()
                .ForMember(dest => dest.OrderMeals, opt => opt.Ignore());
        }
    }
}