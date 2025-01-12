using AutoMapper;
using BooksApi.Data.Context;
using BooksApi.Dto.BookDto;
using BooksApi.Dto.WriterDto;
using BooksApi.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Dto.WriterDto;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WritersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateWriterDto> _validator;

        public WritersController(AppDbContext context, IMapper mapper, IValidator<CreateWriterDto> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectWriterDto>>> GetWriters()
        {
            var writers = await _context.Writers.ToListAsync();
            var selectWriter = _mapper.Map<IEnumerable<SelectWriterDto>>(writers);
            return Ok(selectWriter);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelectWriterDto>> GetWriter(int id)
        {
            var writer = await _context.Writers.FindAsync(id);
            if (writer == null)
                return NotFound();
            var selectWriter = _mapper.Map<SelectWriterDto>(writer);
            return Ok(selectWriter);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWriter(int id)
        {
            var writer = await _context.Writers.FindAsync(id);
            var WriterIsBook = await _context.Books.Where(x => x.Writers.Any<Writer>(x => x.Id == id)).FirstOrDefaultAsync();
            if (WriterIsBook != null)
                return BadRequest(new { message = "Writer is associated with a book" });
            if (writer == null)
                return NotFound();
            _context.Writers.Remove(writer);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Writer deleted successfully" });
        }

        [HttpPost]
        public async Task<ActionResult<SelectWriterDto>> CreateWriter([FromBody] CreateWriterDto createWriterDto)
        {
            var validator = _validator.Validate(createWriterDto);
             if (!validator.IsValid)
                return BadRequest(validator.Errors);
            var writer = _mapper.Map<Writer>(createWriterDto);
            await _context.Writers.AddAsync(writer);
            await _context.SaveChangesAsync();
            var selectWriter = _mapper.Map<SelectWriterDto>(writer);
            return Ok(selectWriter);
        }

        [HttpPut]
        public async Task<ActionResult<SelectWriterDto>> UpdateWriter([FromBody] UpdateWriterDto updateWriterDto)
        {
            var writer = await _context.Writers.FindAsync(updateWriterDto.id);
            if (writer == null)
                return NotFound();
            _mapper.Map(updateWriterDto, writer);
            _context.Writers.Update(writer);
            await _context.SaveChangesAsync();
            var selectWriter = _mapper.Map<SelectWriterDto>(writer);
            return Ok(selectWriter);
        }
    }
}