using ShoesStoreAPI.Models;

namespace ShoesStoreAPI.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>   
    {
        Task<Category> UpdateAsync(Category entity);
    }
}
