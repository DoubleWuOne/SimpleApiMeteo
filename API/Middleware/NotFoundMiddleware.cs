using System.Text.Json;

namespace API.Middleware
{
    public class NotFoundMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);

            if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new
                {
                    error = "NotFound",
                    message = $"Nie znaleziono ścieżki: {context.Request.Path}"
                });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
