using BooksApi.Dto.WriterDto;


namespace BooksApi.Services.Abstract
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