﻿using AutoMapper;
using Contracts.AllModels;
using Contracts.InterFacses;
using Microsoft.AspNetCore.Mvc;
using Restaurant.ViewModelsOrDtos;

namespace Restaurant.Controllers
{
    //ahmad/Meals/Create
    //ahmad/Meals/Update
    //ahmad/Meals/Get

    [ApiController]
    [Route("ahmad/[controller]/[action]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrdersController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateFromEndUser(CreateOrderDto inputFromEndUser)
        {
            var mapping = _mapper.Map<CreateOrderDto, OrderModel>(inputFromEndUser);

            var result = await _orderService.CreateFromEndUser(mapping);

            var afterInsertMapping = _mapper.Map<OrderModel,OrderDto>(result);

            return Ok(afterInsertMapping);
        }



    }
}
