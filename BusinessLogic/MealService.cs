using BusinessObjects.Models;
using BusinessObjects.Interfaces;
using DataAccess.Repositories;

namespace BusinessLogic
{
    public class MealService(IMealRepository repository) : IMealService
    {
        private readonly IMealRepository _repository = repository ?? 
            throw new ArgumentNullException(nameof(repository));

        public async Task<MealModel> CreateAsync(MealModel model)// model => (Repo) => model => Controller
        {
            return await _repository.CreateAsync(model);
        }

        public async Task<MealModel> EditAsync(MealModel model)
        {
            return await _repository.EditAsync(model);
        }

        public async Task<IEnumerable<MealModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<MealModel> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _repository.RemoveAsync(id);
        }
    }
}
