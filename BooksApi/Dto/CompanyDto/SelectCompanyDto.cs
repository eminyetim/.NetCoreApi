namespace BooksApi.Dto.CompanyDto
{
    public class SelectCompanyDto
    {
        public int Id { get; set; } // Şirketin benzersiz kimliği
        public string Name { get; set; } // Şirket adı
        public string Address { get; set; } // Şirket adresi
        public string PhoneNumber { get; set; } // Şirket telefonu
    }
}