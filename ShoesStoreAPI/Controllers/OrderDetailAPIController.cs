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
    public class OrderDetailAPIController : Controller
    {
        private readonly IOrderDetailRepository _db;
        private readonly IOrderRepository _dbOrder;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public OrderDetailAPIController(IOrderDetailRepository db, IMapper mapper, IOrderRepository dbOrder)
        {
            _db = db;
            _response = new();
            _dbOrder = dbOrder;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<APIResponse>> GetOrderDetail(int orderId)
        {
            try
            {
                var list = await _db.GetOrderDetail(orderId);
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<OrderDetailDTO>>(list); ;
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
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> CreateOrderDetail([FromBody] OrderDetailCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                var order = _dbOrder.GetAsync(p => p.Id == createDTO.OrderId);
                if (order == null)
                {
                    return NotFound();
                }
                var model = _mapper.Map<OrderDetail>(createDTO);
                await _db.CreatAsync(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetOrder", new { id = order.Id }, _response);
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
