using LibraryManagementSystem.BLL.DTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace LibraryManagementSystem.BLL.BookValidator;

public class BookValidator : AbstractValidator<BookDto>
{
    public BookValidator()
    {
        RuleFor(b => b.BookTitle)
            .NotEmpty()
            .WithMessage("Title is required.");

        RuleFor(b => b.Genre)
            .IsInEnum()
            .WithMessage("Genre is required.");

        RuleFor(b => b.Description)
            .MaximumLength(300)
            .WithMessage("Description must be at most 300 characters.");

        RuleFor(b => b.AuthorId)
            .GreaterThan(0)
            .WithMessage("An author must be selected.");
    }
}
