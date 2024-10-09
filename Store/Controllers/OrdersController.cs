using BusinessLogic;
using BusinessObjects.Dtos.Orders;
using BusinessObjects.Models.Orders;
using Microsoft.AspNetCore.Mvc;
using BusinessObjects.Dtos.OrderMeal;
using BusinessObjects.Models.OrderMeal;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersBL _ordersBL;
        private readonly MealsBL _mealsBL;

        public OrdersController()
        {
            _ordersBL = new OrdersBL();
            _mealsBL = new MealsBL();
        }

        [HttpPost]
        public ActionResult Create(CreateOrdersDto inputFromUsers)
        {
            // Retrieve the meals based on the list of MealId from input
            var meals = _mealsBL.GetAll().Where(m => inputFromUsers.Orders.Select(i => i.MealId).Contains(m.Id)).ToList();

            if (meals.Count != inputFromUsers.Orders.Count)
            {
                return NotFound(new { message = "Some of the meals provided do not exist." });
            }

            // Create the OrdersModel
            var newOrder = new OrdersModel
            {
                OrderDate = DateTime.Now, 
                Meals = new List<OrderMealModel>(), // Initialize empty meal list
                
            };

            // Loop through each input and find corresponding meal entity
            foreach (var inputMeal in inputFromUsers.Orders)
            {
                var mealEntity = meals.FirstOrDefault(m => m.Id == inputMeal.MealId);
                if (mealEntity != null)
                {

                    // Add to the OrderMealModel list
                    newOrder.Meals.Add(new OrderMealModel
                    {
                        MealId = mealEntity.Id,
                        OrderId = newOrder.Id,  
                        Quantity = inputMeal.Quantity,
                        UnitePrice = mealEntity.Price,
                    });
                }
            }

            // Use OrdersBL to handle the creation of the order
            var createdOrder = _ordersBL.Create(newOrder);

            // Return the created order as a response
            return Ok(createdOrder);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _ordersBL.GetAll();

            // Convert OrdersModel to OrdersDto and map the Meals 
            var modelToDto = result.Select(x => new OrdersDto()
            {
                Id = x.Id,
                OrderNum = x.OrderNum,
                OrderDate = x.OrderDate,
                Total = x.Total,
                MealsCount = x.MealsCount,
                Meals = x.Meals.Select(meal => new OrderMealDto
                {
                    MealId = meal.MealId,
                    OrderId = meal.OrderId,
                    Quantity = meal.Quantity,
                    UnitePrice = meal.UnitePrice
                }).ToList()
            }).ToList();

            return Ok(modelToDto);
        }

        [HttpGet]
        public ActionResult GetById(Guid idFromUsers)
        {
            var result = _ordersBL.GetById(idFromUsers);

            if (result == null)
            {
                return NotFound(new { message = "Order not found" });
            }

            // Convert OrdersModel to OrdersDto and map the Meals 
            var modelToDto = new OrdersDto()
            {
                Id = result.Id,
                OrderNum = result.OrderNum,
                OrderDate = result.OrderDate,
                Total = result.Total,
                MealsCount = result.MealsCount,
                Meals = result.Meals.Select(meal => new OrderMealDto
                {
                    MealId = meal.MealId,
                    OrderId = meal.OrderId,
                    Quantity = meal.Quantity,
                    UnitePrice = meal.UnitePrice
                }).ToList()
            };

            return Ok(modelToDto);
        }


        [HttpPut]
        public ActionResult Edit(EditOrderDto inputFromUser)
        {
            var meals = _mealsBL.GetAll().Where(m => inputFromUser.Orders.Select(i => i.MealId).Contains(m.Id)).ToList();

            if (meals.Count != inputFromUser.Orders.Count)
            {
                return NotFound(new { message = "Some of the meals provided do not exist." });
            }

            // Create the OrdersModel
            var newOrder = new OrdersModel
            {
                OrderDate = DateTime.Now,
                Meals = new List<OrderMealModel>(), 
                Id=inputFromUser.Id,
            };

            // Loop through each input and find corresponding meal entity
            foreach (var inputMeal in inputFromUser.Orders)
            {
                var mealEntity = meals.FirstOrDefault(m => m.Id == inputMeal.MealId);
                if (mealEntity != null)
                {

                    // Add to the OrderMealModel list
                    newOrder.Meals.Add(new OrderMealModel
                    {
                        MealId = mealEntity.Id,
                        OrderId = newOrder.Id,  
                        Quantity = inputMeal.Quantity,
                        UnitePrice = mealEntity.Price,
                    });
                }
            }

            // Use OrdersBL to handle the creation of the order
            var editedOrder = _ordersBL.Edit(newOrder);

            // Return the created order as a response
            return Ok(editedOrder);
        }


        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            var success = _ordersBL.Delete(id);

            if (!success)
            {
                return NotFound(new { message = "Order not found or already deleted" });
            }

            return Ok(new { message = "Order deleted successfully" });
        }

    }
}
