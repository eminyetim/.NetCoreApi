using BooksApi.Dto.BookDto;
using BooksApi.Dto.CompanyDto;
using BooksApi.Models;

namespace BooksApi.Services.Abstract
{
    public interface ICompanyService
    {
        Task<IEnumerable<SelectCompanyDto>> GetAllCompanies();
        Task<CreateCompanyDto> CreateCompanyAsyn(CreateCompanyDto createCompanyto);
    
    }
}