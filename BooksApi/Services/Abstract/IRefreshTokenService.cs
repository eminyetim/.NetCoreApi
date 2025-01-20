using BooksApi.Models;

namespace BooksApi.Services.Abstract
{
    public interface IRefreshTokenService
    {
        public IConfiguration _configuration { get; set; }
        public Token CreateAccessRefreshToken(string RefreshToken);
    }
}