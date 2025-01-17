using BooksApi.Dto.BookDto;
using FluentValidation;

namespace WebApi.FluentValidationApi.Book
{
    public class FluentCreateBook : AbstractValidator<CreateBookDto>
    {
        public FluentCreateBook()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Book title is required.")
                .MinimumLength(3).WithMessage("Book title must be at least 3 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}