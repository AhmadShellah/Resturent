using AutoMapper;
using Contracts.AllModels.MealsModels;
using Contracts.InterFacses;
using Microsoft.AspNetCore.Mvc;
using Restaurant.ViewModelsOrDtos;
using Services;

namespace Restaurant.Controllers
{
    //ahmad/Meals/Create
    //ahmad/Meals/Update
    //ahmad/Meals/Get

    [ApiController]
    [Route("ahmad/[controller]/[action]")]
    public class MealsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMealService _mealService;

        public MealsController(IMapper mapper, IMealService mealService)
        {
            _mapper = mapper;
            _mealService = mealService;
        }

        [HttpPost]
        public ActionResult CreateFromEndUser(CreateMealsDto inputFromEndUser)
        {
            var mapping = _mapper.Map<CreateMealsDto, MealModel>(inputFromEndUser);

            var resultFromService = _mealService.CreateMealService(mapping);

            var mappingToReturnUser = _mapper.Map<MealModel, MealsViewModelOrDto>(resultFromService);

            return Ok(mappingToReturnUser);
            //Retrurn MealsViewModelOrDto
        }

        [HttpPost]
        public ActionResult Create(CreateMealsDto inputFromEndUser)
        {
            var mapping = _mapper.Map<CreateMealsDto, MealModel>(inputFromEndUser);

            var resultFromService = _mealService.CreateMealService(mapping);

            var mappingToReturnUser = _mapper.Map<MealModel, MealsViewModelOrDto>(resultFromService);

            return Ok(mappingToReturnUser);
        }

    }
}
