using FluentValidation;
using MediatR;

namespace PruebasApiSolid.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
     : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var errors = _validators
                    .Select(v => v.Validate(context))
                    .SelectMany(r => r.Errors)
                    .ToList();

                if (errors.Any())
                    throw new ValidationException(errors);
            }

            return await next();
        }
    }

}
