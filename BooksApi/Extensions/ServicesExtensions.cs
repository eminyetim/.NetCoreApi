using FluentValidation;
using WebApi.Dto.WriterDto;
using WebApi.FluentValidationApi.Book;

namespace BooksApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServicesExtension(this IServiceCollection services)
        {
           services.AddTransient<IValidator<CreateWriterDto>, FluentCreateWriter>();
        }
    }
}