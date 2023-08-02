using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Nox.Lib;

public class NoxExceptionHanderMiddleware
{
    private readonly RequestDelegate _next;

    public NoxExceptionHanderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = (int)HttpStatusCode.InternalServerError;
        if (!context.Response.HasStarted)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
        }
        var error = JsonSerializer.Serialize(new
        {
            statusCode,
            exception.Message
        });

        await context.Response.WriteAsync(error);
    }
}