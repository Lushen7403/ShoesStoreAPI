using ShoesStoreAPI.Models;
using ShoesStoreAPI.Models.DTO;

namespace ShoesStoreAPI.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        //Task CreateOrder(Order entity);
        //Task<Order> GetOrder(int id);
        //Task<List<Order>> GetAllOrders(int pageSize = 3, int pageNumber = 1);
    }
}
