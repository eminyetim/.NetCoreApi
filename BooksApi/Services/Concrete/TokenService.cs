using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BooksApi.Models;
using BooksApi.Services.Abstract;
using Microsoft.IdentityModel.Tokens;

namespace BooksApi.Services.Concrete
{
    public class TokenService : ITokenService
    {
        public IConfiguration Configuration { get; set; }

        public TokenService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Token CreateAccessToken(User user)
        {
            // Gizli anahtar kontrolü
            var keyBytes = Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]);
            if (keyBytes.Length < 32)
            {
                throw new Exception("SecurityKey must be at least 256 bits (32 characters) long.");
            }

            Token token = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(keyBytes);
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.Now.AddMinutes(15);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"], // Doğru issuer değeri
                audience: Configuration["Token:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken();
            return token;

        }
        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}