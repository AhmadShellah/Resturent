using AutoMapper;
using Contracts.AllModels.MealsModels;
using Contracts.AllModels.OredrsModels;
using DataCenter.MealManagement;
using DataCenter.OrderManagement;
using Restaurant.ViewModelsOrDtos;
using Restaurant.ViewModelsOrDtos.Order;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateMealsDto, MealModel>().ReverseMap();
        CreateMap<MealModel, MealsViewModelOrDto>().ReverseMap();
        CreateMap<EditMealDto, MealModel>().ReverseMap();
        CreateMap<MealModel, Meal>().ReverseMap();

        //----------------------------------------------

        // Mapping from CreateOrderDto to OrderModel
        CreateMap<CreateOrderDto, OrderModel>()
            .ForMember(dest => dest.Meals, opt => opt.MapFrom(src => src.Orders));

        // Mapping from CreateOrderMealDto to OrderMealModel
        CreateMap<CreateOrderMealDto, OrderMealModel>()
            .ForMember(dest => dest.MealId, opt => opt.MapFrom(src => src.MealId))
            .ForMember(dest => dest.OrderMealDetails, opt => opt.MapFrom(src => new OrderMealDetailModel
            {
                Quantity = src.Quantity,
            }));


        // Mapping from OrderModel to OrderDto
        CreateMap<OrderModel, OrderDto>()
            .ForMember(dest => dest.Meals, opt => opt.MapFrom(src => src.Meals)) // Map Meals
            .ReverseMap();

        // Mapping from OrderMealModel to OredrMealDto
        CreateMap<OrderMealModel, OredrMealDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) // Map OrderMeal Id
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId)) // Map OrderId
            .ForMember(dest => dest.MealId, opt => opt.MapFrom(src => src.MealId)) // Map MealId
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.OrderMealDetails.Quantity)) // Map Quantity from OrderMealDetails
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.OrderMealDetails.UnitPrice)) // Map UnitPrice from OrderMealDetails
            .ReverseMap();



        //CreateMap<List<OrderModel>, List<OrderDto>>();

    }
}
