using AutoMapper;
using BooksApi.Dto.CompanyDto;
using BooksApi.Dto.UserDto;
using BooksApi.Models;

namespace BooksApi.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            // CreateUserDto -> User
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // PasswordHash doğrudan eşlenmez, manuel hashlenir.
                .ForMember(dest => dest.Company, opt => opt.Ignore()); // Company entity kendisi bağlanır.

            // User -> SelectUserDto
            CreateMap<User, SelectUserDto>();

            // Company -> SelectCompanyDto
            CreateMap<Company, SelectCompanyDto>(); // Alt nesne eşlemesi
        }
    }
}
