using AutoMapper;
using BooksApi.Data.Context;
using BooksApi.Dto.BookDto;
using BooksApi.Models;
using BooksApi.Services.Concrete;
using BooksApis.FluentValidationApi.Book;
using FluentAssertions;

namespace BooksApi.UnitTest
{
    public class BookControllerTest : IClassFixture<ControllerTextFixture>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookControllerTest(ControllerTextFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public async void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var book = new Book()
            {
                Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",
                Price = 100
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            var createBook = _mapper.Map<CreateBookDto>(book);
            BookService bookService = new BookService(_context, _mapper);

            await FluentActions
                .Invoking(() => bookService.CreateBookAsyn(createBook))
                .Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Kitap zaten12 mevcut.");
        }

        

        [Theory]
        [InlineData("", 0)]         // title boş, price = 0 => 2 hata
        [InlineData("as", 10)]      // title 2 karakter => 1 hata
        [InlineData("Book", 0)]     // title 4 karakter => 1 hata (price = 0)
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string title, int price)
        {
            // Arrange
            var createBookDto = new CreateBookDto { Title = title, Price = price };

            // Act
            var validationRules = new FluentCreateBook();
            var result = validationRules.Validate(createBookDto);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

    }

}