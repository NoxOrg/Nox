using System.Net;
using System.Text.Json;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Nox.Exceptions;
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
        catch (Exception ex)
        {
            var handler = ex switch
            {
                ConcurrencyException e => CommonHandleExceptionAsync(httpContext, e, e.Message, e.HttpStatusCode),
                TypeValidationException e => HandleTypeValidationExceptionAsync(httpContext, e),
                _ => CommonHandleExceptionAsync(httpContext, ex, ex.Message)
            };

            await handler;
        }
    }

    private async Task HandleTypeValidationExceptionAsync(HttpContext context, TypeValidationException exception)
    {
        var message = string.Join("\n", exception.Errors.Select(x => $"PropertyName: {x.Variable}. Error: {x.ErrorMessage}"));
        await CommonHandleExceptionAsync(context, exception, message, HttpStatusCode.BadRequest);
    }

    private async Task CommonHandleExceptionAsync(HttpContext context,
        Exception exception,
        string errorMessage,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
    {
        var message = $"Error occurred during request: {context.Request?.Path}.Error: {errorMessage}";
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