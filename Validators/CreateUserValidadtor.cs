using FluentValidation;
using TWValidacao.ViewModels;

namespace TWValidacao.Validators;

public class CreateUserValidadtor : AbstractValidator<CreateUserViewModelFluentValidadtion>
{
    public CreateUserValidadtor()
    {
        RuleFor(user => user.FirstName)
            .NotNull().WithMessage("É um compo obrigatorio")
            .NotEmpty().WithMessage("É um compo obrigatorio")
            .MinimumLength(3).WithMessage("Deve ter pelo menos 3 caracteres")
            .MaximumLength(100);

        RuleFor(user => user.LastName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(user => user.Email)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255)
            .EmailAddress();

        RuleFor(user => user.BirthDate)
            .NotNull()
            .NotEmpty();

        RuleFor(user => user.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .Matches("\\([0-9]{2}\\) [0-9]{1} [0-9]{4}-[0-9]{4}");

        RuleFor(user => user.ProfilePicture)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(user => user.Password)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(user => user.PasswordConfirmation)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255)
            .Must((user, passwordCOnfirmation) => string.Equals(passwordCOnfirmation, user.Password));

    }
}