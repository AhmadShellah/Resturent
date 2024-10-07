using BusinessObjects.Models;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class MealRepository
    {
        private readonly static List<Meal> meals = [];

        public async Task<MealModel> CreateAsync(MealModel model)// model => entity =>(DB) => model => BL
        {
            var entity = Mapper.GetEntity(model);

            meals.Add(entity);

            return Mapper.GetModel(entity);
        }

        public async Task<IEnumerable<MealModel>> GetAllAsync()
        {
            return meals.Where(m => !m.IsDeleted)
                .Select(m => Mapper.GetModel(m))
                .ToList();
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var meal =  meals.FirstOrDefault(m => m.Id == id && !m.IsDeleted);

            if (meal is null)
            {
                return false;
            }
            else
            {
                meal.SetIsDeleted();

                return true;
            }
        }

        public async Task<MealModel?> GetByIdAsync(Guid id)
        {
            var meal = meals.FirstOrDefault(m => m.Id == id && !m.IsDeleted);
            if (meal is null)
            {
                return null;
            }
            else
            {
                return Mapper.GetModel(meal);
            }
        }

        public async Task<bool> EditAsync(MealModel model)
        {
            var order = meals.FirstOrDefault(m => m.Id == model.Id && !m.IsDeleted);
            if(order is null)
            {
                return false;
            }
            else
            {
                order.Price = model.Price;
                order.Weight = model.Weight;
                order.Calories = model.Calories;
                order.Details = model.Details;
                order.Name = model.Name;

                return true;
            }
        }
    }
}
