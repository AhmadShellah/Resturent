using BusinessObjects.Models;
using DataAccess.Repositories;

namespace BusinessLogic
{
    public class MealService
    {
        private readonly MealRepository repository;

        public MealService()
        {
            repository = new MealRepository();
        }

        public async Task<MealModel> CreateAsync(MealModel model)// model => (Repo) => model => Controller
        {
            return await repository.CreateAsync(model);
        }

        public async Task<bool> EditAsync(MealModel model)
        {
            return await repository.EditAsync(model);
        }

        public async Task<IEnumerable<MealModel>> GetAllAsync()
        {
            return await repository.GetAllAsync();      
        }

        public async Task<MealModel?> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            return await repository.RemoveAsync(id);
        }
    }
}
