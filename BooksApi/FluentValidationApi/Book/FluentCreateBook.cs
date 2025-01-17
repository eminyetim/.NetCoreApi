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
                .MinimumLength(2).WithMessage("Book title must be at least  2 chearecters.");
        }
    }
}