
using AutoMapper;
using BooksApi.Dto.CompanyDto;
using BooksApi.Models;

namespace BooksApi.Mapping
{
    public class CompanyMapping : Profile
    {
        public CompanyMapping()
        {
            CreateMap<SelectCompanyDto,Company >().ReverseMap();
            CreateMap<CreateCompanyDto,Company >().ReverseMap();
        }
    }
}