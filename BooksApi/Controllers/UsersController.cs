using BooksApi.Dto.UserDto;
using BooksApi.Services.Abstract;
using BooksApi.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectUserDto>>> GetUser()
        {
            var companies = await _service.GetAllUsers();
            return Ok(companies);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserDto>> CreateUser([FromBody] CreateUserDto createWriterDto)
        {
            try
            {
                var createWriter = await _service.CreateUserAsyn(createWriterDto);
                return Ok(createWriter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}