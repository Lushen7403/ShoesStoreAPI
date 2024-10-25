using ShoesStoreAPI.Data;
using ShoesStoreAPI.Models;
using ShoesStoreAPI.Repository.IRepository;

namespace ShoesStoreAPI.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly ApplicationDbContext _db;
        public BrandRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Brand> UpdateAsync(Brand entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
