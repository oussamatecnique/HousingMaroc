using FluentValidation;
using HousingMaroc.Application.Users.Commands;

namespace HousingMaroc.Application.Users.Validators;

public class AddUserCommandValidator: AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8);
        
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(@"^(\+212|0)([ \-_/]*)(\d[ \-_/]*){9}$");
    }
}
