using PruebasApiSolid.Application.Common;

namespace PruebasApiSolid.Middleware
{
    public class MiddlewareExceptions
    {
        private readonly RequestDelegate _requestDelegate;

        public MiddlewareExceptions(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);

            }catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "application/json";

                var response = ApiResponse<string>.Ok(ex.Message);

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
