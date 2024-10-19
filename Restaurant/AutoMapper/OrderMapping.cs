using AutoMapper;
using Contracts.AllModels;
using Restaurant.ViewModelsOrDtos;

namespace Restaurant.AutoMapper
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<CreateOrderDto, OrderModel>();
            CreateMap<OrderModel, OrderDto>()
                .ForMember(dest => dest.OrderId, src => src.MapFrom(src => src.Id))
                .ForMember(dest => dest.DueDate, src => src.MapFrom(src => src.DueDate.ToString("yyyy,MM,dd")));
        }
    }
}
