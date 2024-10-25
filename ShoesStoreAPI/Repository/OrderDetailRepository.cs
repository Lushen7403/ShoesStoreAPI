using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoesStoreAPI.Data;
using ShoesStoreAPI.Models;
using ShoesStoreAPI.Models.DTO;
using ShoesStoreAPI.Repository.IRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ShoesStoreAPI.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<OrderDetail>> GetOrderDetail(int orderId)
        {
            var list = _db.OrderDetails.Where(p => p.OrderId == orderId);
            return await list.ToListAsync();
        }
    }
}
