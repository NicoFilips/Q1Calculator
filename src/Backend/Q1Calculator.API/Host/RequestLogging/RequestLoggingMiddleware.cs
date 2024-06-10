using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Q1Calculator.API.Host.RequestLogging;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Handling request: {Method} {Url}");
        _logger.LogInformation("Handling request: {Method} {Url}", context.Request.Method, context.Request.Path);

        // Call the next middleware in the pipeline
        await _next(context);

        _logger.LogInformation("Finished handling request.");
    }
}
