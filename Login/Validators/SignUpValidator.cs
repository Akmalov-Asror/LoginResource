using FluentValidation;
using Login.DTOS;

namespace Login.Validators;

public class SignUpValidator : AbstractValidator<SignUpDto>
{
    public SignUpValidator()
    {
        RuleFor(signUpDto => signUpDto.Password)
            .MinimumLength(8)
            .NotEmpty()
            .Matches(@"^[a-zA-Z0-9]+$")
            .WithMessage("Minimum length 8, password must contain at least one letter, one number and one special character.");
    }
}