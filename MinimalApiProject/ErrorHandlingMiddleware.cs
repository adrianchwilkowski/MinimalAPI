using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MinimalApiProject.Exceptions;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace MinimalApiProject
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (!context.Response.HasStarted)
                    await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        public Task HandleException(HttpContext context, Exception ex)
        {
            if (context.Response.HasStarted) return Task.CompletedTask;

            var code = HttpStatusCode.InternalServerError;
            string? result = null;
            switch (ex)
            {

                case NullReferenceException:
                    code = HttpStatusCode.NotFound;
                    break;
                case NoContentException:
                    code = HttpStatusCode.NoContent;
                    break;
                case Exception:
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.ContentType = "application/text";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(ex.Message);
        }
    }

    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
