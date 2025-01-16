using AutoMapper;
using BooksApi.Data.Context;
using BooksApi.Dto.BookDto;
using BooksApi.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Services.Abstract;

namespace WebApi.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        public async Task<IEnumerable<SelectBookDto>> GetAllBooksAsync()
        {
            var books = await _context.Books
                .Include(b => b.Genres)
                .Include(b => b.Writers)
                .ToListAsync();

            return _mapper.Map<IEnumerable<SelectBookDto>>(books);
        }
        
        
        public BookService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IEnumerable<CreateBookDto>> CreateBookDto(CreateBookDto createBookDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteWriteAsync(int id)
        {
            throw new NotImplementedException();
        }

      

        public Task<SelectBookDto> GetByIdBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SelectBookDto> UpdateBookDto(UpdateBookDto updateBookDto)
        {
            throw new NotImplementedException();
        }
    }
}