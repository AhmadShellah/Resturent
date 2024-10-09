using BusinessObjects.Models.Meals;

namespace DataAccess.Meals
{
    public class MealsRepo
    {
        private readonly static List<MealsEntity> _meals = new();

        public MealsModel Create(MealsModel inputFromDev)
        {
            var ModelToEntity = new MealsEntity()
            {
                Id = inputFromDev.Id,
                Name = inputFromDev.Name,
                Code = inputFromDev.Code,
                Price = inputFromDev.Price,
                Weight = inputFromDev.Weight,
                Calories = inputFromDev.Calories,
                Description = inputFromDev.Description,
            };

            _meals.Add(ModelToEntity);

            return inputFromDev;
        }

        public List<MealsModel> GetAll()
        {
            var result = _meals.Where(a=>a.IsDeleted!=true).Select(s => new MealsModel()
            {
                Id = s.Id,
                Name = s.Name,
                Code = s.Code,
                Price = s.Price,
                Weight = s.Weight,
                Calories = s.Calories,
                Description = s.Description,
            }).ToList();

            return result;
        }

        public MealsModel GetById(Guid idFromUser)
        {
            var result = _meals.Where(a => a.IsDeleted != true && a.Id == idFromUser).Select(s => new MealsModel()
            {
                Id = s.Id,
                Name = s.Name,
                Code = s.Code,
                Price = s.Price,
                Weight = s.Weight,
                Calories = s.Calories,
                Description = s.Description,
            }).FirstOrDefault();

            return result;
        }

        public MealsModel? Edit(MealsModel inputFromDev)
        {
            // Search for the meal by its unique Id
            var mealEntity = _meals.FirstOrDefault(m => m.Id == inputFromDev.Id);
            if (mealEntity != null)
            {
                // Update the existing meal details
                mealEntity.Name = inputFromDev.Name;
                mealEntity.Price = inputFromDev.Price;
                mealEntity.Weight = inputFromDev.Weight;
                mealEntity.Calories = inputFromDev.Calories;
                mealEntity.Description = inputFromDev.Description;

                return inputFromDev; // Return updated model
            }

            return null; // Return null if no matching meal is found
        }

        public bool Delete(Guid inputId)
        {
            // Search for the meal by its unique Id
            var meal = _meals.FirstOrDefault(m => m.Id == inputId);

            if (meal != null && meal.IsDeleted!=true )
            {
                meal.SetIsDeleted();
                return true;
            }

            return false;
        }
    }
}
