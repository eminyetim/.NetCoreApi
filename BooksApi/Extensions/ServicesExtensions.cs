using BooksApi.Data.Context;
using BooksApi.Dto.BookDto;
using FluentValidation;
using BooksApi.Data.Abstract;
using BooksApi.Dto.WriterDto;
using BooksApi.FluentValidationApi.Writer;
using BooksApi.Services.Abstract;
using BooksApi.Services.Concrete;
using BooksApis.FluentValidationApi.Book;

namespace BooksApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IWirterService,WriterService>();

            services.AddScoped<ICompanyService,CompanyService>();
            services.AddScoped<IUserService,UserService>();


            services.AddTransient<IValidator<CreateWriterDto>, FluentCreateWriter>();
            services.AddTransient<IValidator<CreateBookDto>,FluentCreateBook>();

            services.AddScoped<IAppDbContext, AppDbContext>();
        }
    }
}