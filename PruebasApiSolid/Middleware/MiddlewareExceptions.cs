using Microsoft.Extensions.Logging;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Common.Exceptions;
using PruebasApiSolid.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace PruebasApiSolid.Middleware
{
    public class MiddlewareExceptions
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<MiddlewareExceptions> _logger;

        public MiddlewareExceptions(RequestDelegate requestDelegate, ILogger<MiddlewareExceptions> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);

            }catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
            
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var response = ex switch
            {
                NotFoundException => (
                    StatusCodes.Status404NotFound,
                    ApiResponse<string>.Fail(ex.Message)
                ),

                ValidationExceptions => (
                    StatusCodes.Status400BadRequest,
                    ApiResponse<string>.Fail(ex.Message)
                ),

                ConflictExceptions => (
                    StatusCodes.Status409Conflict,
                    ApiResponse<string>.Fail(ex.Message)
                ),

                DomainExceptions => (
                    StatusCodes.Status422UnprocessableEntity,
                    ApiResponse<string>.Fail(ex.Message)
                ),

                _ => (
                    StatusCodes.Status500InternalServerError,
                    ApiResponse<string>.Fail("Error interno del servidor")
                )
            };

            context.Response.StatusCode = response.Item1;
            await context.Response.WriteAsJsonAsync(response.Item2);
        }

    }
}
