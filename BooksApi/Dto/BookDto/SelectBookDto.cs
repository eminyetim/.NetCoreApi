using BooksApi.Dto.GenreDto;
using BooksApi.Dto.WriterDto;


namespace BooksApi.Dto.BookDto
{
    public class SelectBookDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public List<SelectGenreDto> Genres { get; set; }
        public List<SelectWriterDto> Writers { get; set; }
    }
}