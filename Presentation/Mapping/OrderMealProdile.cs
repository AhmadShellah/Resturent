using AutoMapper;
using BusinessObjects.Dtos.OrderMeal;
using BusinessObjects.Models;

namespace Presentation.Mapping
{
    public class OrderMealProdile: Profile
    {
        public OrderMealProdile()
        {
            CreateMap<CreateOrderMealDto, OrderMealModel>();
            CreateMap<EditOrderMealDto, OrderMealModel>();
            CreateMap<OrderMealModel, OrderMealDto>();
        }
    }
}
