using BooksApi.Dto.WriterDto;
using WebApi.Dto.WriterDto;

namespace WebApi.Services.Abstract
{
    public interface IWirterService 
    {
        Task<IEnumerable<SelectWriterDto>> GetAllWriterAsync();
        Task<SelectWriterDto> GetByIdWriterAsync(int id);
        Task<CreateWriterDto> CreateWriterAsync(CreateWriterDto createWriterDto);
        Task<SelectWriterDto> UpdateWriterAsync(UpdateWriterDto updateWriterDto);
        Task<bool> DeleteWriterAsync(int id);
    }
}