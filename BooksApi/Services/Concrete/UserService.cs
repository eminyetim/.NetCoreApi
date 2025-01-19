using AutoMapper;
using BooksApi.Dto.UserDto;
using BooksApi.Models;
using BooksApi.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using BooksApi.Data.Abstract;

namespace BooksApi.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateUserDto> CreateUserAsyn(CreateUserDto createUserDto)
        {
            try
            {
                // Şirketin varlığını kontrol et
                var company = await _context.Companies.FindAsync(createUserDto.CompanyId);
                if (company == null)
                {
                    throw new Exception("Şirket bulunamadı.");
                }

                // Kullanıcıyı DTO'dan User modeline map et
                var user = _mapper.Map<User>(createUserDto);

                // Şifreyi hashle
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);

                // Şirketi kullanıcıya bağla
                user.Company = company;

                // Kullanıcıyı ekle
                await _context.Users.AddAsync(user);

                // Veritabanına kaydet
                await _context.SaveChangesAsync();

                return createUserDto;
            }
            catch (Exception ex)
            {
                // Hata loglama (isteğe bağlı)
                Console.WriteLine($"Hata: {ex.Message}");

                // Hatanın üst katmana fırlatılması
                throw;
            }
        }

        public async Task<IEnumerable<SelectUserDto>> GetAllUsers()
        {
            var users = await _context.Users.Include(u => u.Company).ToListAsync();
            return _mapper.Map<IEnumerable<SelectUserDto>>(users);
        }
    }
}