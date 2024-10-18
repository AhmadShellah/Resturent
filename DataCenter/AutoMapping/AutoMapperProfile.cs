using AutoMapper;
using Contracts.AllModels.MealsModels;
using Contracts.AllModels.OredrsModels;
using DataCenter.MealManagement;
using DataCenter.OrderManagement;
using DataCenter.OrderMealsManagement;

namespace DataCenter.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Meal mappings
            CreateMap<Meal, MealModel>();
            CreateMap<MealModel, Meal>()
                .ForMember(s => s.Id, c => c.Ignore());

            //---------------------------------------------------------------



            // Mapping from OrderModel to Order
            CreateMap<OrderModel, Order>()
                .ForMember(dest => dest.Meals, opt => opt.MapFrom(src => src.Meals))
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore the Id so it doesn't overwrite it if not intended
                .ReverseMap();

            // Mapping from OrderMealModel to OrderMeal
            CreateMap<OrderMealModel, OrderMeal>()
                .ForMember(dest => dest.MealId, opt => opt.MapFrom(src => src.MealId))
                .ForMember(dest => dest.OrderMealDetails, opt => opt.MapFrom(src => src.OrderMealDetails))
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore the Id
                .ReverseMap();

            // Mapping from OrderMealDetailModel to OrderMealDetails
            CreateMap<OrderMealDetailModel, OrderMealDetails>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore the Id
                .ReverseMap();

            //CreateMap<List<Order>, List<OrderModel>>();

        }
    }
    }
    

