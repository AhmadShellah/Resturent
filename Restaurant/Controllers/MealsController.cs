using AutoMapper;
using Contracts.AllModels.MealsModels;
using Contracts.InterFacses;
using Microsoft.AspNetCore.Mvc;
using Restaurant.ViewModelsOrDtos;
using Services;
using System.Collections.Generic;

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
        public ActionResult CreateFromEndUser(CreateMealsDto inputFromEndUser)
        {
            var mapping = _mapper.Map<CreateMealsDto, MealModel>(inputFromEndUser);
            var resultFromService = _mealService.CreateMealService(mapping);
            var mappingToReturnUser = _mapper.Map<MealModel, MealsViewModelOrDto>(resultFromService);
            return Ok(mappingToReturnUser);
        }


        // Get all meals or a specific meal by ID
        [HttpGet]
        public ActionResult<IEnumerable<MealsViewModelOrDto>> GetMeals(Guid? id = null)
        {
            var resultFromService = _mealService.GetMealService(id);
            var mappingToReturn = _mapper.Map<IEnumerable<MealModel>>(resultFromService);
            return Ok(mappingToReturn);
        }

        // Edit a meal
        [HttpPut]
        public ActionResult EditMeal(EditMealDto inputFromUser)
        {
            var mapping = _mapper.Map<EditMealDto, MealModel>(inputFromUser);
            var resultFromService = _mealService.EditMealService(mapping);

            if (resultFromService == null)
            {
                return NotFound("Meal not found");
            }

            var mappingToReturnUser = _mapper.Map<MealModel, MealsViewModelOrDto>(resultFromService);
            return Ok(mappingToReturnUser);
        }

        // Delete a meal by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteMeal(Guid id)
        {
            var resultFromService = _mealService.DeleteMealService(id);

            if (!resultFromService)
            {
                return NotFound("Meal not found or could not be deleted");
            }

            return Ok("Meal deleted successfully");
        }
    }
}
