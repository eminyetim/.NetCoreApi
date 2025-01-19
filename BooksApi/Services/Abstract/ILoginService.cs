
using BooksApi.Models;

namespace BooksApi.Services.Abstract
{
    public interface ILoginService
    {
        public Token Login(CreateTokenModel createTokenModel);
    }
}