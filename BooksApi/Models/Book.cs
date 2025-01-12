namespace BooksApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public ICollection<Genre> Genres {get;set;}
        public ICollection<Writer> Writers { get; set; }
    }
}
