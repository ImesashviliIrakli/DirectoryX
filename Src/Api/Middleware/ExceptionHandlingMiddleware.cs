using Domain.Abstractions;
using Domain.Enums;
using Domain.Errors;
using System.Net;
using System.Text.Json;

namespace Api.Middleware;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = Result.Failure(GlobalStatusCodes.SystemFailure, GlobalErrors.SystemFailure);

            string json = JsonSerializer.Serialize(result);

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);
        }
    }
}
