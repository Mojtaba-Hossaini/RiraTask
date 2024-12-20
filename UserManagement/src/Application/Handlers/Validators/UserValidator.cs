using Core.Entities;
using FluentValidation;

namespace Application.Handlers.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty").MinimumLength(3).WithMessage("Name must be at least 3 characters");
        RuleFor(x => x.Family).NotEmpty().WithMessage("Family cannot be empty").MinimumLength(3).WithMessage("Family must be at least 3 characters");
        RuleFor(x => x.NationalCode).NotEmpty().WithMessage("NationalCode cannot be empty")
                                      .Length(12).WithMessage("NationalCode must be 12 characters long")
                                      .Matches(@"^\d+$").WithMessage("NationalCode must be numeric");
        RuleFor(x => x.Birthday).LessThan(DateTime.Now.AddYears(-18)).WithMessage("User must be older than 18");
    }
}
