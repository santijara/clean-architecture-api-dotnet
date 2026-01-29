using FluentValidation;

namespace PruebasApiSolid.Application.Users.Commands.CreateUser
{
    public class CreateUserValidator
     : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name)
                 .MaximumLength(100).WithMessage("Maximo 100 caracteres");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email invalido");

            RuleFor(x => x.Password)
                .MinimumLength(8).WithMessage("Minimo 8 caracteres");
        }
    }
}
