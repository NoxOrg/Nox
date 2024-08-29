using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nox.Exceptions;
using Nox.Types;

namespace Nox.Lib;

internal class ExceptionHanderMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHanderMiddleware> _logger;

    public ExceptionHanderMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHanderMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext, IWebHostEnvironment webHostEnvironment)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex) when (ex.InnerException is IApplicationException exception)
        {
            await CommonHandleExceptionAsync(
                httpContext,
                ex,
                exception.ErrorCode,
                exception.ErrorDetails,
                exception.DisplayMessage,
                exception.StatusCode,
                webHostEnvironment.IsDevelopment());
        }
        catch (Exception ex) when (ex is IApplicationException exception) 
        {
            await CommonHandleExceptionAsync(
                httpContext, 
                ex, 
                exception.ErrorCode,
                exception.ErrorDetails, 
                exception.DisplayMessage,
                exception.StatusCode,
                webHostEnvironment.IsDevelopment());
        }        
        catch (Exception ex)
        {
            await CommonHandleExceptionAsync(
                httpContext, 
                ex,
                null,
                null,
                "An unexpected error occurred",
                HttpStatusCode.InternalServerError,
                webHostEnvironment.IsDevelopment());
        }
    }

    /// <summary>
    /// Setup the client response in case of unhandled exception
    /// </summary>
    /// <param name="context"></param>
    /// <param name="exception"></param>
    /// <param name="errorCode">A short string with a brief explanation of the error to be returned to the client</param>
    /// <param name="errorDetails">Optional: A complex object with more details about the error to be returned to the client</param>
    /// <param name="statusCode">The Http Status Code</param>
    /// <returns></returns>
    private async Task CommonHandleExceptionAsync(
        HttpContext context,
        Exception exception,
        string? errorCode,
        object? errorDetails,
        string displayMessage,
        HttpStatusCode? statusCode,
        bool isDevelopmentEnvironment)
    {
        _logger.LogError(exception, "Error occurred during request: {Path}", context.Request?.Path);

        if (!context.Response.HasStarted)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)(statusCode??HttpStatusCode.InternalServerError);
        }

        var error = JsonSerializer.Serialize(new
        {
            error = new
            {
                message = displayMessage,
                //Unique id for this error type, use error code if provided, otherwise use the exception type name
                id = Nuid.From(errorCode ?? exception.GetType().FullName!).ToString(),
                code = errorCode ?? "undefined",
                details = isDevelopmentEnvironment ? errorDetails : "hidden",
                exception = isDevelopmentEnvironment ? exception.ToString(): "hidden"
            }
        });

        await context.Response.WriteAsync(error);
    }
}