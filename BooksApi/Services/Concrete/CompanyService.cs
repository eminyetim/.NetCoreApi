using AutoMapper;
using BooksApi.Data.Context;
using BooksApi.Dto.CompanyDto;
using BooksApi.Models;
using BooksApi.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using BooksApi.Data.Abstract;

namespace BooksApi.Services.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CompanyService(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateCompanyDto> CreateCompanyAsyn(CreateCompanyDto createCompanyto)
        {
            var company = _mapper.Map<Company>(createCompanyto);

            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return createCompanyto;
        }

        public async Task<IEnumerable<SelectCompanyDto>> GetAllCompanies()
        {
            var companies =  await _context.Companies.ToListAsync();
            return _mapper.Map<IEnumerable<SelectCompanyDto>>(companies);
        }
    }
}