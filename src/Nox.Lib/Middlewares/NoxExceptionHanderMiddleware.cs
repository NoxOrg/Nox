using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Nox.Types;

namespace Nox.Lib;

public class NoxExceptionHanderMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<NoxExceptionHanderMiddleware> _logger;

    public NoxExceptionHanderMiddleware(
        RequestDelegate next,
        ILogger<NoxExceptionHanderMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex) when (ex is INoxHttpException httpException)
        {
            await CommonHandleExceptionAsync(httpContext, ex, httpException.StatusCode);
        }
        catch (Exception ex)
        {
            await CommonHandleExceptionAsync(httpContext, ex, HttpStatusCode.InternalServerError);
        }
    }

    private async Task CommonHandleExceptionAsync(HttpContext context,
        Exception exception,
        HttpStatusCode statusCode)
    {
        var message = $"Error occurred during request: {context.Request?.Path}.Error: {exception.Message}";

        _logger.LogError(exception, message);

        if (!context.Response.HasStarted)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
        }

        var error = JsonSerializer.Serialize(new
        {
            statusCode,
            message
        });

        await context.Response.WriteAsync(error);
    }
}