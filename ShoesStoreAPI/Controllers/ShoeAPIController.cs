using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoesStoreAPI.Models;
using ShoesStoreAPI.Models.DTO;
using ShoesStoreAPI.Repository.IRepository;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace ShoesStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeAPIController : Controller
    {
        private readonly IShoeRepository _shoeRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public ShoeAPIController(IShoeRepository shoeRepo, IMapper mapper)
        {
            _shoeRepo = shoeRepo;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<APIResponse>> GetShoes([FromQuery] string? search, int pageSize = 2, int pageNumber = 1)
        {
            try
            {
                IEnumerable<Shoe> shoeList;
                if(!string.IsNullOrEmpty(search))
                {
                    shoeList = await _shoeRepo.GetAllAsync(p => p.Name.ToLower().Contains(search.ToLower()), pageSize:pageSize, pageNumber:pageNumber);
                }
                else
                {
                    shoeList = await _shoeRepo.GetAllAsync(pageSize:pageSize, pageNumber:pageNumber);
                }
                var pagination = new Pagination()
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<ShoeDTO>>(shoeList);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpGet("{id:int}",Name = "GetShoe")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<APIResponse>> GetShoe(int id)
        {
            try
            {
                if(id == 0)
                {
                    return BadRequest();
                }
                var shoe = await _shoeRepo.GetAsync(p => p.Id == id);
                if(shoe == null)
                {
                    return NotFound();
                }
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<ShoeDTO>(shoe);
                _response.StatusCode = HttpStatusCode.OK;
            } catch (Exception ex)  
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
        public async Task<ActionResult<APIResponse>> CreateShoe([FromBody] ShoeCreateDTO createDTO)
        {
            try
            {
                if(createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                if(await _shoeRepo.GetAsync(p => p.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Shoe shoe = _mapper.Map<Shoe>(createDTO);
                await _shoeRepo.CreatAsync(shoe);
                _response.Result = _mapper.Map<ShoeCreateDTO>(shoe);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetShoe", new { id = shoe.Id }, _response);
            } catch (Exception ex)
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
        public async Task<ActionResult<APIResponse>> DeleteShoe(int id)
        {
            try
            {
                if(id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var shoe = await _shoeRepo.GetAsync(p => p.Id == id);
                if(shoe == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _shoeRepo.RemoveAsync(shoe);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            } catch (Exception ex)
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
        public async Task<ActionResult<APIResponse>> UpdateShoe(int id, [FromBody] ShoeUpdateDTO updateDTO)
        {
            try
            {
                if(updateDTO == null || updateDTO.Id != id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                Shoe model = _mapper.Map<Shoe>(updateDTO);
                await _shoeRepo.UpdateAsync(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            } catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
    }
}
