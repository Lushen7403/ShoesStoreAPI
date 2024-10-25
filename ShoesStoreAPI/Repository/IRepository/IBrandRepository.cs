using ShoesStoreAPI.Models;

namespace ShoesStoreAPI.Repository.IRepository
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<Brand> UpdateAsync(Brand entity);
    }
}
