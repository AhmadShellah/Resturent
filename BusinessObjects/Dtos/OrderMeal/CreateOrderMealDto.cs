using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Dtos.OrderMeal
{
    public class CreateOrderMealDto
    {
        public Guid MealId { get; set; }

        public int Quantity { get; set; }
    }
}
