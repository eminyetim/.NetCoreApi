using System.Threading.Tasks;
using BooksApi.Dto.UserDto;
using BooksApi.Models;
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
        private readonly ILoginService _serviceLogin;

        public UsersController(IUserService service, ILoginService serviceToken)
        {
            _service = service;
            _serviceLogin = serviceToken;
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
        [HttpPost("concreate/token")]
        public ActionResult<Token> CreateToken(CreateTokenModel login)
        {
            try
            {
                return _serviceLogin.Login(login);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}