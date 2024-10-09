using BusinessLogic;
using BusinessObjects.Dtos.Meals;
using BusinessObjects.Models.Meals;
using Microsoft.AspNetCore.Mvc;


namespace Store.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class MealsController : ControllerBase
    {
        private readonly MealsBL _mealsBL;

        public MealsController()
        {
            _mealsBL = new MealsBL();
        }

        [HttpPost]
        public ActionResult Create(CreateMealsDto inputFromUser)
        {
            var dtoToModel = new MealsModel()
            {
                Name = inputFromUser.Name,
                Code = inputFromUser.Code,
                Price = inputFromUser.Price,
                Weight = inputFromUser.Weight,
                Calories = inputFromUser.Calories,
                Description = inputFromUser.Description,
            };

            var result = _mealsBL.Create(dtoToModel);

            var modelToDto = new MealsDto()
            {
                Id = result.Id,
                Name = result.Name,
                Code = result.Code,
                Price = result.Price,
                Weight = result.Weight,
                Calories = result.Calories,
                Description = result.Description,
            };

            return Ok(modelToDto);
        }

        // Get all meals
        [HttpGet]
        public ActionResult Get()
        {
            var result = _mealsBL.GetAll();

            var modelToDto = result.Select(x => new MealsDto()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Price = x.Price,
                Weight = x.Weight,
                Calories = x.Calories,
                Description = x.Description,
            }).ToList();

            return Ok(modelToDto);
        }

        // Get meal by ID
        [HttpGet]
        public ActionResult GetById(Guid id)
        {
            var result = _mealsBL.GetById(id);

            if (result == null)
            {
                return NotFound(new { message = "Meal not found" });
            }

            var modelToDto = new MealsDto()
            {
                Id = result.Id,
                Name = result.Name,
                Code = result.Code,
                Price = result.Price,
                Weight = result.Weight,
                Calories = result.Calories,
                Description = result.Description,
            };

            return Ok(modelToDto);
        }

        // Get meals by calorie range
        [HttpGet]
        public ActionResult GetByCalorieRange(int minCalories, int maxCalories)
        {
            var result = _mealsBL.GetByCalorieRange(minCalories, maxCalories);

            var modelToDto = result.Select(x => new MealsDto()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Price = x.Price,
                Weight = x.Weight,
                Calories = x.Calories,
                Description = x.Description,
            }).ToList();

            return Ok(modelToDto);
        }

        // Edit meal
        [HttpPut]
        public ActionResult Edit(MealsDto inputFromUser)
        {
            var dtoToModel = new MealsModel()
            {
                Id = inputFromUser.Id,
                Name = inputFromUser.Name,
                Code = inputFromUser.Code,
                Price = inputFromUser.Price,
                Weight = inputFromUser.Weight,
                Calories = inputFromUser.Calories,
                Description = inputFromUser.Description,
            };

            var result = _mealsBL.Edit(dtoToModel);

            if (result == null)
            {
                return NotFound(new { message = "Meal not found" });
            }

            var modelToDto = new MealsDto()
            {
                Id = result.Id,
                Name = result.Name,
                Code = result.Code,
                Price = result.Price,
                Weight = result.Weight,
                Calories = result.Calories,
                Description = result.Description,
            };

            return Ok(new { message = "Meal updated successfully", data = modelToDto });

        }

        // Delete meal by ID
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            var success = _mealsBL.Delete(id);

            if (!success)
            {
                return NotFound(new { message = "Meal not found or already deleted" });
            }

            return Ok(new { message = "Meal deleted successfully" });
        }
    }
}
