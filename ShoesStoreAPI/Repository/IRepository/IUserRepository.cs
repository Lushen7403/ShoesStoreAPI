using ShoesStoreAPI.Models;
using ShoesStoreAPI.Models.DTO;

namespace ShoesStoreAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool isUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<Account> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
