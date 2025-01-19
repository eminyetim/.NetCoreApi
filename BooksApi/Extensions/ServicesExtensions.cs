using BooksApi.Data.Context;
using BooksApi.Dto.BookDto;
using FluentValidation;
using BooksApi.Data.Abstract;
using BooksApi.Dto.WriterDto;
using BooksApi.FluentValidationApi.Writer;
using BooksApi.Services.Abstract;
using BooksApi.Services.Concrete;
using BooksApis.FluentValidationApi.Book;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

namespace BooksApi.Extensions
{
    public static class ServicesExtensions
    {

        public static void AddServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IWirterService, WriterService>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<ILoginService,LoginService>();

            services.AddTransient<IValidator<CreateWriterDto>, FluentCreateWriter>();
            services.AddTransient<IValidator<CreateBookDto>, FluentCreateBook>();



            services.AddScoped<IAppDbContext, AppDbContext>();
        }
    }
}