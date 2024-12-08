namespace RouteWiseApp.API.Middlewares
{
    using Serilog;
    using System.Diagnostics;
    using System.Text.Json;

    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Incomming request 
            var stopwatch = Stopwatch.StartNew();
            var request = context.Request;
            Log.Information("Incoming Request: {Method} {Path} {QueryString}", request.Method, request.Path, request.QueryString);

            // Out going response
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            try
            {
                await _next(context);

                stopwatch.Stop();
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                Log.Information("Outgoing Response: {StatusCode} {Body} (Elapsed: {ElapsedMs}ms)", context.Response.StatusCode, responseText, stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                Log.Error(ex, "An error occurred while processing the request (Elapsed: {ElapsedMs}ms)", stopwatch.ElapsedMilliseconds);
                throw;
            }
            finally
            {
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
    }

}
