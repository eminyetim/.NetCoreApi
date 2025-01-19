namespace BooksApi.Dto.CompanyDto
{
    public class CreateCompanyDto
    {
        public string Name { get; set; } // Şirket adı
        public string Address { get; set; } // Şirket adresi
        public string PhoneNumber { get; set; } // Şirket telefonu

        // Şirketin kullanıcıları
    }
}