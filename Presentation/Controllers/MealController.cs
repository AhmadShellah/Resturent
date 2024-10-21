using AutoMapper;
using BusinessObjects.Dtos.Meal;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MealController(IMealService service, IMapper mapper) : ControllerBase
    {
        private readonly IMealService _service = service ?? 
            throw new ArgumentNullException(nameof(service));

        private readonly IMapper _mapper = mapper ?? 
            throw new ArgumentNullException(nameof(mapper));

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateMealDto meal) // dto => model =>(BL)=> model => dto;
        {
            var model = _mapper.Map<MealModel>(meal);

            var returnedModel = await _service.CreateAsync(model);

            return Ok(_mapper.Map<MealDto>(returnedModel));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var returnedList = await _service.GetAllAsync();

            var dtoList = _mapper.Map<List<MealDto>>(returnedList);

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var mealModel = await _service.GetByIdAsync(id);

                return Ok(_mapper.Map<MealDto>(mealModel));
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
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] EditMealDto editedMeal)
        {
            try
            {
                var model = _mapper.Map<MealModel>(editedMeal);

                var returnedModel = await _service.EditAsync(model);

                return Ok(_mapper.Map<MealDto>(returnedModel));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
