using FluentValidation;
using LibraryManagementSystem.BLL.DTos;

namespace LibraryManagement.BLL.AuthorManagement.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.FullName)
                .NotEmpty()
                .Must(FourNamesWithTwo)
                .WithMessage("Full name must Contain of 4 names, each at least 2 characters long.");

            RuleFor(a => a.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email must be in a valid format.");

            RuleFor(a => a.Bio)
                .MaximumLength(300);
        }

        private bool FourNamesWithTwo(string fullName)
        {
            var names = fullName?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return names is { Length: 4 } && names.All(n => n.Length >= 2);
        }
    }
}