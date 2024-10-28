using AutoMapper;
using Contracts.AllModels.OredrsModels;
using Contracts.InterFacses;
using Microsoft.AspNetCore.Mvc;
using Restaurant.ViewModelsOrDtos.Order;

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
        public async Task<ActionResult> CreateOrder(CreateOrderDto inputFromUser)
        {

            // Map the CreateOrderDto to OrderModel
            var orderModel = _mapper.Map<OrderModel>(inputFromUser);
            var order = await _orderService.CreateOrder(orderModel);
            var result = _mapper.Map<OrderDto>(order);
            return Ok(result);
        }

        // Get all orders or a specific order by ID
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var resultFromService = await _orderService.GetOrders();
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
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            var resultFromService = await _orderService.DeleteOrder(id);

            if (!resultFromService)
            {
                return NotFound("Order not found or could not be deleted.");
            }

            return Ok("Meal deleted successfully");
        }


    }
}
