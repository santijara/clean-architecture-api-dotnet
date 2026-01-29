using Microsoft.AspNetCore.Mvc;
using PruebasApiSolid.Application.Common;

namespace PruebasApiSolid.Extensions
{
    public static class ApiBehaviorExtensions
    {
        public static IServiceCollection AddApiBehavior(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(x => x.Value.Errors.Any())
                        .Select(x => new
                        {
                            Field = x.Key,
                            Errors = x.Value.Errors.Select(e => e.ErrorMessage)
                        });

                    return new BadRequestObjectResult(
                        ApiResponse<object>.Fail("Errores de validación", errors)
                    );
                };
            });

            return services;
        }
    }
}
