using BooksApi.Dto.BookDto;
using BooksApi.Dto.CompanyDto;
using BooksApi.Dto.UserDto;
using BooksApi.Models;

namespace BooksApi.Services.Abstract
{
    public interface IUserService
    {
        Task<IEnumerable<SelectUserDto>> GetAllUsers();
        Task<CreateUserDto> CreateUserAsyn(CreateUserDto createUserDto);
    }
}