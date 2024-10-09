using BusinessObjects.Models.Meals;
using DataAccess.Meals;

namespace BusinessLogic
{
    public class MealsBL
    {
        private readonly MealsRepo _mealsRepo;

        public MealsBL()
        {
            _mealsRepo = new MealsRepo();
        }

        public MealsModel Create(MealsModel inputFromUser)
        {
            var result = _mealsRepo.Create(inputFromUser);
            return result;
        }

        public List<MealsModel> GetAll()
        {
            var result = _mealsRepo.GetAll();
            return result;
        }

        // GetById method
        public MealsModel GetById(Guid idFromUser)
        {
            var result = _mealsRepo.GetById(idFromUser);
            return result;
        }

        //  Edit method
        public MealsModel Edit(MealsModel inputFromUser)
        {
            var result = _mealsRepo.Edit(inputFromUser);
            return result;
        }

        //  Delete method
        public bool Delete(Guid idFromUser)
        {
            var result = _mealsRepo.Delete(idFromUser);
            return result;
        }

        //  GetByCalorieRange method
        public List<MealsModel> GetByCalorieRange(int minCalories, int maxCalories)
        {
            var allMeals = _mealsRepo.GetAll();
            var result = allMeals
                .Where(m => m.Calories >= minCalories && m.Calories <= maxCalories)
                .ToList();

            return result;
        }
    }
}
