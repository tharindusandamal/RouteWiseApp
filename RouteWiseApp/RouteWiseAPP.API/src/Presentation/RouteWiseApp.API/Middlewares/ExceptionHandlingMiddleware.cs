using RouteWiseApp.APPLICATION.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace RouteWiseApp.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Hanlde application exceptions
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // TODO: Add all possible exceptions to hndle here
            var statusCode = exception switch
            {
                InvalidException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError,
            };

            // TODO: Need to use a rich object model (wrapper) with more detals | Ex: error codes, status message with the http context 
            var response = new
            {
                Error = exception.Message,
                StatusCode = (int)statusCode
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
