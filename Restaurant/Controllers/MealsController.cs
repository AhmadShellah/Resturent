using AutoMapper;
using Contracts.AllModels.MealsModels;
using Contracts.InterFacses;
using Microsoft.AspNetCore.Mvc;
using Restaurant.ViewModelsOrDtos;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MealsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMealService _mealService;

        public MealsController(IMapper mapper, IMealService mealService)
        {
            _mapper = mapper;
            _mealService = mealService;
        }

        // Create meal for end user
        [HttpPost]
        public async Task<ActionResult> CreateFromEndUser(CreateMealsDto inputFromEndUser)
        {
            var mapping = _mapper.Map<CreateMealsDto, MealModel>(inputFromEndUser);
            var resultFromService = await _mealService.CreateMealService(mapping);
            var mappingToReturnUser = _mapper.Map<MealModel, MealsViewModelOrDto>(resultFromService);
            return Ok(mappingToReturnUser);
        }


        // Get all meals or a specific meal by ID
        [HttpGet]
        public async Task<ActionResult> GetMeals()
        {
            var resultFromService = await _mealService.GetMeals();
            var mappingToReturn = _mapper.Map<List<MealModel>, List<MealsViewModelOrDto>>(resultFromService.ToList());
            return Ok(mappingToReturn);
        }

        [HttpGet]
        public async Task<ActionResult> GetMealById(Guid id)
        {
            var resultFromService = await _mealService.GetMealById(id);
            if (resultFromService == null)
            {
                return NoContent();
            }
            var mappingToReturn = _mapper.Map<MealModel,MealsViewModelOrDto>(resultFromService);
            return Ok(mappingToReturn);
        }

        // Edit a meal
        [HttpPut]
        public async Task<ActionResult> EditMeal(EditMealDto inputFromUser)
        {
            var mapping = _mapper.Map<EditMealDto, MealModel>(inputFromUser);
            try
            {

                var resultFromService = await _mealService.EditMealService(mapping);
                var mappingToReturnUser = _mapper.Map<MealModel, MealsViewModelOrDto>(resultFromService);
                return Ok(mappingToReturnUser);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Delete a meal by ID
       [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMeal(Guid id)
        {
            var resultFromService = await _mealService.DeleteMealService(id);

            if (!resultFromService)
            {
                return NotFound("Meal not found or could not be deleted");
            }

            return Ok("Meal deleted successfully");
        }
    }
}
