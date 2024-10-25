using Microsoft.IdentityModel.Tokens;
using ShoesStoreAPI.Data;
using ShoesStoreAPI.Models;
using ShoesStoreAPI.Models.DTO;
using ShoesStoreAPI.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoesStoreAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private string SecretKey;
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            SecretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        public bool isUniqueUser(string username)
        {
            var user = _db.Accounts.FirstOrDefault(p => p.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.Accounts.FirstOrDefault(p => p.UserName.ToLower() == loginRequestDTO.UserName.ToLower()
            && p.Password == loginRequestDTO.Password);
            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Account = null,
                    Token = ""
                };
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                Account = user
            };
            return loginResponseDTO;
        }

        public async Task<Account> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            Account user = new Account
            {
                UserName = registerationRequestDTO.UserName,
                Password = registerationRequestDTO.Password,
                Name = registerationRequestDTO.Name,
                Email = registerationRequestDTO.Email,
                Address = registerationRequestDTO.Address,
                Role = registerationRequestDTO.Role,
            };
            _db.Accounts.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
