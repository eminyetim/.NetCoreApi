namespace BooksApi.Models
{
    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}