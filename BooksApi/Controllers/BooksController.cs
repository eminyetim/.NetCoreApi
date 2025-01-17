using BooksApi.Dto.BookDto;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Abstract;

namespace BooksApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectBookDto>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<CreateBookDto>> CreateBooks(CreateBookDto createBookDto)
        {
            try
            {
                var book = await _bookService.CreateBookDto(createBookDto);
                return book;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBooks(int id)
        {
            var result = await _bookService.DeleteWriteAsync(id);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelectBookDto>> GetByIdBook(int id)
        {
            try
            {
                var result = await _bookService.GetByIdBookAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<UpdateBookDto>> UpdateBook(UpdateBookDto updateBookDto)
        {
            try
            {
                return await _bookService.UpdateBookDto(updateBookDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}