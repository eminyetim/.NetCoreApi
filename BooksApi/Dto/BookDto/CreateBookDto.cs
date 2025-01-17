namespace BooksApi.Dto.BookDto
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public List<int> GenreIds { get; set; } = new List<int>();
        public List<int> WriterIds { get; set; } = new List<int>();
    }
}