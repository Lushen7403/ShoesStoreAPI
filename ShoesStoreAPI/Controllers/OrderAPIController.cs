using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoesStoreAPI.Models;
using ShoesStoreAPI.Models.DTO;
using ShoesStoreAPI.Repository.IRepository;
using System.Net;
using System.Security.Claims;

namespace ShoesStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPIController : Controller
    {
        private readonly IOrderRepository _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public OrderAPIController(IOrderRepository db, IMapper mapper)
        {
            _db = db;
            _response = new();
            _mapper = mapper;
        }
        [HttpGet("{id:int}", Name = "GetOrder")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> GetOrder(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var order = await _db.GetAsync(p => p.Id == id);
                if (order == null)
                {
                    return NotFound();
                }
                _response.IsSuccess = true;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = _mapper.Map<OrderDTO>(order);
            }
           
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<APIResponse>> GetAllOrder(int pageSize = 2, int pageNumber = 1)
        {
            try
            {
                var list = await _db.GetAllAsync(pageSize:pageSize, pageNumber:pageNumber);
                var pagination = new Pagination()
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<OrderDTO>>(list); ;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> CreateOrder([FromBody] OrderCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                var model = _mapper.Map<Order>(createDTO);
                model.AccountId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                await _db.CreatAsync(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetOrder", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
    }
}
