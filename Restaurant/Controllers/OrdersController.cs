using AutoMapper;
using Contracts.AllModels.OredrsModels;
using Contracts.InterFacses;
using Microsoft.AspNetCore.Mvc;
using Restaurant.ViewModelsOrDtos.Order;
using System;
using System.Collections.Generic;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrdersController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        // Create a new order
        [HttpPost]
        public ActionResult CreateOrder(CreateOrderDto inputFromUser)
        {

            // Map the CreateOrderDto to OrderModel
            var orderModel = _mapper.Map<OrderModel>(inputFromUser);
            var order = _orderService.CreateOrder(orderModel);
            return Ok(order);
        }

        // Get all orders or a specific order by ID
        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetOrders(Guid? id = null)
        {
            var resultFromService = _orderService.GetOrders(id);
            var mappingToReturn = _mapper.Map<IEnumerable<OrderDto>>(resultFromService);
            return Ok(mappingToReturn);
        }

        //// Edit an existing order
        //[HttpPut("{id}")]
        //public ActionResult<OrderDto> EditOrder(OrderModel updatedOrderModel)
        //{
        //    if (updatedOrderModel == null)
        //    {
        //        return BadRequest("Updated order model is null.");
        //    }

        //    var resultFromService = _orderService.EditOrder(updatedOrderModel);

        //    if (resultFromService == null)
        //    {
        //        return NotFound("Order not found.");
        //    }

        //    var mappingToReturnUser = _mapper.Map<OrderDto>(resultFromService);
        //    return Ok(mappingToReturnUser);
        //}

        //// Delete an order by ID
        //[HttpDelete("{id}")]
        //public ActionResult DeleteOrder(Guid id)
        //{
        //    var resultFromService = _orderService.DeleteOrder(id);

        //    if (!resultFromService)
        //    {
        //        return NotFound("Order not found or could not be deleted.");
        //    }

        //    return NoContent(); // Return 204 No Content
        //}

        //// Get a specific order by ID (for the CreatedAtAction)
        //[HttpGet("{id}")]
        //public ActionResult<OrderModel> GetOrder(Guid id)
        //{
        //    var order = _orderService.GetOrders(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(order);
        //}
    }
}
