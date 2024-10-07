using BusinessLogic;
using BusinessObjects.Dtos.Order;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService service;

        public OrderController()
        {
            service = new OrderService();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderDto order)
        {
            var model = Mapper.GetModel(order);

            var returnedModel = await service.CreateAsync(model);

            return Ok(Mapper.GetDto(returnedModel));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var returedList = await service.GetAllAsync();

            var dtoList = returedList.Select(o => Mapper.GetDto(o)).ToList();

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            var orderModel = await service.GetByIdAsync(id);

            if(orderModel is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.GetDto(orderModel));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove([FromRoute] Guid id)
        {
            var ok = await service.RemoveAsync(id);

            if (ok)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] EditOrderDto editOrder)
        {
            var ok = await service.EditAsync(Mapper.GetModel(editOrder));

            if (ok)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
