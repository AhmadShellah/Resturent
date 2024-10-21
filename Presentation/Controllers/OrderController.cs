using AutoMapper;
using BusinessObjects.Dtos.Order;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController(IOrderService service, IMapper mapper) : ControllerBase
    {
        private readonly IOrderService _service = service ??
            throw new ArgumentNullException(nameof(service));

        private readonly IMapper _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderDto order)
        {
            try
            {
                var model = _mapper.Map<OrderModel>(order);

                var returnedModel = await _service.CreateAsync(model);

                return Ok(_mapper.Map<OrderDto>(returnedModel));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var returedList = await _service.GetAllAsync();

            var dtoList = _mapper.Map<IEnumerable<OrderDto>>(returedList);

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var orderModel = await _service.GetByIdAsync(id);

                return Ok(_mapper.Map<OrderDto>(orderModel));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] EditOrderDto editOrder)
        {
            try
            {
                var model = _mapper.Map<OrderModel>(editOrder);

                await _service.EditAsync(model);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove([FromRoute] Guid id)
        {
            try
            {
                await _service.RemoveAsync(id);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
