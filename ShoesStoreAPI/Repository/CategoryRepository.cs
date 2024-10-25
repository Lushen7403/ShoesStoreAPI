using ShoesStoreAPI.Data;
using ShoesStoreAPI.Models;
using ShoesStoreAPI.Repository.IRepository;

namespace ShoesStoreAPI.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Category> UpdateAsync(Category entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
