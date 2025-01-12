namespace BooksApi.Dto.BookDto
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int GenreId { get; set; }
        public int WriterId { get; set; }
    }
}