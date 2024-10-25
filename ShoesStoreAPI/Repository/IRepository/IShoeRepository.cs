using ShoesStoreAPI.Models;

namespace ShoesStoreAPI.Repository.IRepository
{
    public interface IShoeRepository : IRepository<Shoe>
    {
        Task<Shoe> UpdateAsync(Shoe entity);
    }
}
