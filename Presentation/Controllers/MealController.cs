using BusinessLogic;
using BusinessObjects.Dtos.Meal;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly MealService service;

        public MealController()
        {
            service = new MealService();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateMealDto meal) // dto => model =>(BL)=> model => dto;
        {
            var model = Mapper.GetModel(meal);

            var returnedModel = await service.CreateAsync(model);

            return Ok(Mapper.GetDto(returnedModel));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var returnedList = await service.GetAllAsync();

            var dtoList = returnedList.Select(m => Mapper.GetDto(m)).ToList();

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            var mealModel = await service.GetByIdAsync(id);

            if (mealModel is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.GetDto(mealModel));
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
        public async Task<ActionResult> Edit([FromBody] EditMealDto editedMeal)
        {
            var ok = await service.EditAsync(Mapper.GetModel(editedMeal));

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
