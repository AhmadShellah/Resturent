using BusinessObjects.Models.Orders;
using DataAccess.Orders;

namespace BusinessLogic
{
    public class OrdersBL
    {
        private readonly OrdersRepo _ordersRepo;

        public OrdersBL()
        {
            _ordersRepo = new OrdersRepo();
        }

        public OrdersModel Create(OrdersModel inputFromUsers)
        {
            //Logic
            inputFromUsers.MealsCount = inputFromUsers.Meals.Count;

            inputFromUsers.Total = inputFromUsers.Meals.Sum(s=>s.UnitePrice * s.Quantity);

            var result = _ordersRepo.Create(inputFromUsers);
            return result;
        }

        public List<OrdersModel> GetAll()
        {
            var result = _ordersRepo.GetAll();
            return result;

        }

        // GetById method
        public OrdersModel GetById(Guid idFromUser)
        {
            var result = _ordersRepo.GetById(idFromUser);
            return result;
        }

        public OrdersModel Edit(OrdersModel inputFromUsers)
        {
            //Logic
            inputFromUsers.MealsCount = inputFromUsers.Meals.Count;

            inputFromUsers.Total = inputFromUsers.Meals.Sum(s => s.UnitePrice * s.Quantity);

            var result = _ordersRepo.Edit(inputFromUsers);
            return result;
        }


        public bool Delete(Guid idFromUser)
        {
            var result = _ordersRepo.Delete(idFromUser);
            return result;
        }
    }
}
