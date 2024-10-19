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
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;

        public OrdersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //private readonly IMealService _mealService;


        [HttpPost]
        public ActionResult CreateFromEndUser(CreateMealsDto inputFromEndUser)
        {
           
        }

      

    }
}
