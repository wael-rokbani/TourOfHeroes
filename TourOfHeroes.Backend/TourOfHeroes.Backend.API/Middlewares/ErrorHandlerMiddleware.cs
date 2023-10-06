using System.Text.Json;

namespace TourOfHeroes.Backend.API.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
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

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;

        //TODO Custom Error Handling

        response.ContentType = "application/json";
        var result = JsonSerializer.Serialize(exception);
        await response.WriteAsync(result);
    }
}
