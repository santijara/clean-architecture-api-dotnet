using FluentValidation;

namespace PruebasApiSolid.Application.Users.Commands.UpdateUser
{
    public class UpdateUserValidator: AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id invalido");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email invalido");
        }
    }
}
