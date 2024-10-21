using AutoMapper;
using BusinessObjects.Dtos.Order;
using BusinessObjects.Models;

namespace Presentation.Mapping
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderDto, OrderModel>();
            CreateMap<EditOrderDto, OrderModel>();
            CreateMap<OrderModel, OrderDto>();
        }
    }
}
