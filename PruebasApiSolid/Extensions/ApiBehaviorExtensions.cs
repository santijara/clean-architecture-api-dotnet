using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PruebasApiSolid.Application.Common;

namespace PruebasApiSolid.Extensions
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException ex)
            {
                var errors = ex.Errors
                    .GroupBy(e => e.PropertyName)
                    .Select(g => new
                    {
                        Field = g.Key,
                        Errors = g.Select(e => e.ErrorMessage)
                    });

                context.Result = new BadRequestObjectResult(
                    ApiResponse<object>.Fail("Errores de validación", errors)
                );

                context.ExceptionHandled = true;
            }
        }
    }

}
