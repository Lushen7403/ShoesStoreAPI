using Microsoft.AspNetCore.Mvc;
using ShoesStoreAPI.Models.DTO;
using ShoesStoreAPI.Models;
using ShoesStoreAPI.Repository.IRepository;
using System.Net;

namespace ShoesStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAPIController : Controller
    {
        private readonly IUserRepository _userRepository;
        protected APIResponse _response;
        public AccountAPIController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new APIResponse();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            LoginResponseDTO loginResponse = await _userRepository.Login(model);
            if (loginResponse.Account == null && string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("UserName or Password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDTO model)
        {
            bool isUserNameUnique = _userRepository.isUniqueUser(model.UserName);
            if (!isUserNameUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("UserName already exist");
                return BadRequest(_response);
            }
            var user = await _userRepository.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
