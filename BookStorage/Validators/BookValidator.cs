using BookStorage.Models;
using FluentValidation;

namespace BookStorage.Validators;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Укажите id книги");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Укажите название книги");
        RuleFor(x => x.Author).NotEmpty().WithMessage("Укажите автора книги");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Укажите описание книги");
        RuleFor(x => x.Page).NotEmpty().WithMessage("Укажите количество страниц");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Укажите цену");
    }
}