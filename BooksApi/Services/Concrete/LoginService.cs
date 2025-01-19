using System.Threading.Tasks;
using AutoMapper;
using BooksApi.Data.Abstract;
using BooksApi.Models;
using BooksApi.Services.Abstract;

namespace BooksApi.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public LoginService(IAppDbContext context, IMapper mapper, IConfiguration configuration, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        public Token Login(CreateTokenModel Model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email && x.PasswordHash == Model.PasswordHash);
            if (user is not null)
            {
                _tokenService.Configuration = _configuration;
                Token token = _tokenService.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChangesAsync();
                return token;
            }
            else
                throw new InvalidDataException("Email or Password is not valid.");
        }
    }
}