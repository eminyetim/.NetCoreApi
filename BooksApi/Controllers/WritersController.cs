using BooksApi.Dto.WriterDto;
using Microsoft.AspNetCore.Mvc;
using BooksApi.Services.Abstract;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WritersController : ControllerBase
    {
        private readonly IWirterService _writerService;

        public WritersController(IWirterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectWriterDto>>> GetWriters()
        {
            var writer = await _writerService.GetAllWriterAsync();
            return Ok(writer);
        }

        [HttpPost]
        public async Task<ActionResult<SelectWriterDto>> CreateWriter([FromBody] CreateWriterDto createWriterDto)
        {
            try
            {
                var createWriter = await _writerService.CreateWriterAsync(createWriterDto);
                return Ok(createWriter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelectWriterDto>> GetWriter(int id)
        {
            try
            {
                var result = await _writerService.GetByIdWriterAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteWriter(int id)
        {
            try
            {
                return await _writerService.DeleteWriterAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<SelectWriterDto>> UpdateWriter([FromBody] UpdateWriterDto updateWriterDto)
        {
            try
            {
                return await _writerService.UpdateWriterAsync(updateWriterDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}