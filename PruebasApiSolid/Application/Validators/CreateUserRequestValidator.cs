using FluentValidation;
using PruebasApiSolid.Application.Dtos;

namespace PruebasApiSolid.Application.Validators
{
    public class CreateUserRequestValidator: AbstractValidator<RequestUser>
    {
        public CreateUserRequestValidator()
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
