namespace BooksApi.Models
{
    public class Company
    {

        public int Id { get; set; } // Şirketin benzersiz kimliği
        public string Name { get; set; } // Şirket adı
        public string Address { get; set; } // Şirket adresi
        public string PhoneNumber { get; set; } // Şirket telefonu

        // Şirketin kullanıcıları
        public List<User> Users { get; set; } = new List<User>();

    }
}