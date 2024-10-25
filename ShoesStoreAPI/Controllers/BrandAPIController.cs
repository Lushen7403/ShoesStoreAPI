using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoesStoreAPI.Models;
using ShoesStoreAPI.Models.DTO;
using ShoesStoreAPI.Repository.IRepository;
using System.Net;

namespace ShoesStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandAPIController : Controller
    {
        private readonly IBrandRepository _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public BrandAPIController(IBrandRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<APIResponse>> GetCategories()
        {
            try
            {
                var brandList = await _db.GetAllAsync();
                _response.IsSuccess = true;
                _response.Result = brandList;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetBrand")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<APIResponse>> GetBrand(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var brand = await _db.GetAsync(p => p.Id == id);
                if (brand == null)
                {
                    return NotFound();
                }
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<BrandDTO>(brand);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<APIResponse>> CreateBrand([FromBody] BrandCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                if (await _db.GetAsync(p => p.BrandName.ToLower() == createDTO.BrandName.ToLower()) != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Brand brand = _mapper.Map<Brand>(createDTO);
                await _db.CreatAsync(brand);
                _response.Result = _mapper.Map<BrandCreateDTO>(brand);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetShoe", new { id = brand.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> DeleteBrand(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var brand = await _db.GetAsync(p => p.Id == id);
                if (brand == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _db.RemoveAsync(brand);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> UpdateBrand(int id, [FromBody] BrandUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || updateDTO.Id != id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                Brand model = _mapper.Map<Brand>(updateDTO);
                await _db.UpdateAsync(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
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
