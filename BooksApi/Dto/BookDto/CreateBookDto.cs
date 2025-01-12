namespace BooksApi.Dto.BookDto
{
    public class CreateBookDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int GenreId { get; set; }
        public int WriterId { get; set; }
    }
}