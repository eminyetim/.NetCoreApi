using AutoMapper;
using BooksApi.Data.Context;
using BooksApi.Dto.BookDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Controller
{
    [ApiController]
    [Route("api/controller")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectBookDto>>> GetBooks()
        {
            var books = await _context.Books
            .Include(b => b.Genres)
            .Include(b => b.Writers)
            .ToListAsync();

            var selectBook = _mapper.Map<IEnumerable<SelectBookDto>>(books);
            return Ok(selectBook);
        }
    }
}