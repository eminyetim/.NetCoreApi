using BooksApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Services.Abstract
{
    public interface ITokenService
    {
        public IConfiguration Configuration { get; set; }
        public Token CreateAccessToken(User user);
    }
}