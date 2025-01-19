using BooksApi.Dto.CompanyDto;
using BooksApi.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompaniesController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectCompanyDto>>> GetBooks()
        {
            var companies = await _service.GetAllCompanies();
            return Ok(companies);
        }
        
        [HttpPost]
        public async Task<ActionResult<CreateCompanyDto>> CreateWriter([FromBody] CreateCompanyDto createWriterDto)
        {
            try
            {
                var createWriter = await _service.CreateCompanyAsyn(createWriterDto);
                return Ok(createWriter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}