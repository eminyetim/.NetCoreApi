using AutoMapper;
using BooksApi.Data.Context;
using BooksApi.Dto.BookDto;
using BooksApi.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Abstract;
using WebApi.Services.Abstract;

namespace WebApi.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookDto> _validator;

        public BookService(IAppDbContext context, IMapper mapper, IValidator<CreateBookDto> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IEnumerable<SelectBookDto>> GetAllBooksAsync()
        {
            var books = await _context.Books
                .Include(b => b.Genres)
                .Include(b => b.Writers)
                .ToListAsync();

            return _mapper.Map<IEnumerable<SelectBookDto>>(books);
        }

        public async Task<CreateBookDto> CreateBookDto(CreateBookDto createBookDto)
        {
            var validator = _validator.Validate(createBookDto);
            if (!validator.IsValid)
                throw new Exception($"Doğrulama hatası:{validator.Errors}");

            // 2. Manually create a new Book (or use AutoMapper for part of this)
            var book = new Book
            {
                Title = createBookDto.Title,
                Price = createBookDto.Price
                // We won't set Genres and Writers yet
            };

            // 3. Fetch genres from the DB by their IDs
            var genres = await _context.Genres
                .Where(g => createBookDto.GenreIds.Contains(g.Id))
                .ToListAsync();

            // 4. Fetch writers from the DB by their IDs
            var writers = await _context.Writers
                .Where(w => createBookDto.WriterIds.Contains(w.Id))
                .ToListAsync();

            // 5. Attach them to the Book entity
            book.Genres = genres;
            book.Writers = writers;
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return createBookDto;
        }
        public async Task<bool> DeleteWriteAsync(int id)
        {
            // 1. Adım: Kitabı, Writers ve Genres tablolarıyla birlikte çekelim
            var book = await _context.Books
                .Include(b => b.Writers) // Book-Writers
                .Include(b => b.Genres)  // Book-Genres
                .FirstOrDefaultAsync(b => b.Id == id);

            // 2. Kitap yoksa false dön
            if (book == null)
            {
                return false;
            }

            // 3. Kitabın Writers ve Genres koleksiyonlarını temizle
            //    => Bu işlem EF Core tarafından ilişkileri (join tablosundaki satırları) silecektir.
            book.Writers.Clear();
            book.Genres.Clear();

            // 4. Artık kitabın kendisini silebiliriz
            _context.Books.Remove(book);

            // 5. Değişiklikleri kaydet
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<SelectBookDto> GetByIdBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                throw new Exception("Book is could not be find !");
            return _mapper.Map<SelectBookDto>(book);
        }



        public async Task<UpdateBookDto> UpdateBookDto(UpdateBookDto updateBookDto)
        {
            var book = await _context.Books.FindAsync(updateBookDto.Id);
            if (book == null)
                throw new Exception("Book is could not be find!");
            _mapper.Map(updateBookDto, book);
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            var selectBook = _mapper.Map<UpdateBookDto>(book);
            return selectBook;
        }
    }
}