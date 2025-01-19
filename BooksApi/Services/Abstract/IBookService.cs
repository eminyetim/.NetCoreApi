using BooksApi.Dto.BookDto;
using BooksApi.Models;

namespace BooksApi.Services.Abstract
{
    public interface IBookService
    {
        Task<IEnumerable<SelectBookDto>> GetAllBooksAsync();
        Task<SelectBookDto> GetByIdBookAsync(int id);
        Task<CreateBookDto> CreateBookAsyn(CreateBookDto createBookDto);
        Task<UpdateBookDto> UpdateBookDto(UpdateBookDto updateBookDto);
        Task<bool> DeleteWriteAsync(int id);
    }
}