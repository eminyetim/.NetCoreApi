using BooksApi.Dto.BookDto;

namespace WebApi.Services.Abstract
{
    public interface IBookService
    {
        Task<IEnumerable<SelectBookDto>> GetAllBooksAsync();
        Task<SelectBookDto> GetByIdBookAsync(int id);
        Task<IEnumerable<CreateBookDto>> CreateBookDto(CreateBookDto createBookDto);
        Task<SelectBookDto> UpdateBookDto(UpdateBookDto updateBookDto);
        Task<bool> DeleteWriteAsync(int id);
    }
}