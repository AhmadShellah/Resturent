using AutoMapper;
using BusinessObjects.Dtos.OrderMealDetails;
using BusinessObjects.Models;

namespace Presentation.Mapping
{
    public class OrderMealDetails: Profile
    {
        public OrderMealDetails()
        {
            CreateMap<CreateOrderMealDetailsDto, OrderMealDetailsModel>();
            CreateMap<EditOrderMealDetailsDto, OrderMealDetailsModel>();
            CreateMap<OrderMealDetailsModel, OrderMealDetailsDto>();
        }
    }
}
