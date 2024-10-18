using AutoMapper;
using Contracts.AllModels.MealsModels;
using DataCenter.MealsManagement;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataCenter.MealManagement
{
    public class MealRepository : IMealRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public MealRepository(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // Create a new meal
        public MealModel CreateObjectInDataBase(MealModel inputFromDeveloper)
        {
            var mappingToInsert = _mapper.Map<MealModel, Meal>(inputFromDeveloper);
            _context.Meals.Add(mappingToInsert);
            _context.SaveChanges();

            var mappingToReturn = _mapper.Map<Meal, MealModel>(mappingToInsert);
            return mappingToReturn;
        }

        // Get meals based on ID (if provided) or all meals if no ID is provided
        public IEnumerable<MealModel> GetMeals(Guid? id = null)
        {
            var meals = _context.Meals
                .Where(m => !m.IsDeleted && (!id.HasValue || m.Id == id.Value)) // Filter by IsDeleted
                .ToList();

            return _mapper.Map<List<Meal>, List<MealModel>>(meals);
        }


        // Edit an existing meal
        public MealModel? EditMeal(MealModel updatedMealModel)
        {
            var meal = _context.Meals.FirstOrDefault(m => m.Id == updatedMealModel.Id); // Get the meal by Id from the updatedMealModel
            if (meal != null)
            {
                _mapper.Map(updatedMealModel, meal); // Map the updated fields to the existing meal entity
                _context.Entry(meal).State = EntityState.Modified;
                _context.SaveChanges();

                return _mapper.Map<Meal, MealModel>(meal); // Return the updated meal model
            }
            return null; // Return null if the meal with the given Id was not found
        }


        public bool DeleteMeal(Guid id)
        {
            var meal = _context.Meals.FirstOrDefault(m => m.Id == id);
            if (meal != null)
            {
                meal.SetIsDeleted(); // Mark the meal as deleted
                _context.SaveChanges(); // Save changes to the database
                return true;
            }
            return false;
        }
    }
}
