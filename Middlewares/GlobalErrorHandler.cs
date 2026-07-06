using Ecommerce_Backend.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Ecommerce_Backend.Middlewares
{
    public class GlobalErrorHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var statusCodes = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                BadRequestException => StatusCodes.Status400BadRequest,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                ForbiddenException => StatusCodes.Status403Forbidden,
                ConflictException => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };
            httpContext.Response.StatusCode = statusCodes;
            var response = new
            {
                statusCodes,
                message = exception.Message
            };
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;

        }
    }
}