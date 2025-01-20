using AutoMapper;
using BooksApi.Data.Abstract;
using BooksApi.Models;
using BooksApi.Services.Abstract;

namespace BooksApi.Services.Concrete
{
    public class RefreshToken : IRefreshTokenService
    {
        private readonly IAppDbContext _context;
    
        public ITokenService _tokenService;
        public IConfiguration _configuration { get; set; }

        public RefreshToken(IAppDbContext contex, IConfiguration Configuration)
        {
            _context = contex;
            _configuration = Configuration;
        }

        public Token CreateAccessRefreshToken(string RefreshToken)
        {
            var user = _context.Users.FirstOrDefault(x=> x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
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