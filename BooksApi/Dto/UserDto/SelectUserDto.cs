using BooksApi.Dto.CompanyDto;

namespace BooksApi.Dto.UserDto
{
    public class SelectUserDto
    {
        public int Id { get; set; } // Kullanıcının benzersiz kimliği
        public string UserName { get; set; } // Kullanıcı adı
        public string Email { get; set; } // Kullanıcı emaili
        public string PasswordHash { get; set; } // Şifre hash
        public SelectCompanyDto Company { get; set; } // Kullanıcının bağlı olduğu şirketin kimliği

    }
}