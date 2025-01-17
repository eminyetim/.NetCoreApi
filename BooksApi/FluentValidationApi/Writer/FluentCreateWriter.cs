using BooksApi.Dto.BookDto;
using FluentValidation;
using WebApi.Dto.WriterDto;

namespace WebApi.FluentValidationApi.Writer
{
    public class FluentCreateWriter : AbstractValidator<CreateWriterDto>
    {
        public FluentCreateWriter()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Writer name is required")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters");
        }
    }
}