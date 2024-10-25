using ShoesStoreAPI.Models;
using ShoesStoreAPI.Models.DTO;

namespace ShoesStoreAPI.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        Task <List<OrderDetail>> GetOrderDetail(int orderId);
    }
}
