using ShoesStoreAPI.Data;
using ShoesStoreAPI.Models;
using ShoesStoreAPI.Repository.IRepository;

namespace ShoesStoreAPI.Repository
{
    public class ShoeRepository : Repository<Shoe>, IShoeRepository
    {
        private readonly ApplicationDbContext _db;
        public ShoeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Shoe> UpdateAsync(Shoe entity)
        {
            entity.UpdateTime = DateTime.Now;
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
