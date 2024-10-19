using AutoMapper;
using Contracts.AllModels;
using DataCenter.OrderManagement;

namespace DataCenter
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, OrderModel>().ReverseMap();
        }
    }
}
