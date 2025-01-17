using BooksApi.Dto.BookDto;
using FluentValidation;
using WebApi.Dto.WriterDto;
using WebApi.FluentValidationApi.Book;
using WebApi.FluentValidationApi.Writer;
using WebApi.Services.Abstract;
using WebApi.Services.Concrete;

namespace BooksApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IWirterService,WriterService>();


            services.AddTransient<IValidator<CreateWriterDto>, FluentCreateWriter>();
            services.AddTransient<IValidator<CreateBookDto>,FluentCreateBook>();
        }
    }
}