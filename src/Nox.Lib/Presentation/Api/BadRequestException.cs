using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Nox.Exceptions;

public class BadRequestException : Exception, IApplicationException
{
    public BadRequestException(ModelStateDictionary modelState, string? errorCode = null) : base("bad request")
    {
        ErrorDetails = new SerializableError(modelState);

        if (errorCode != null)
        {
            ErrorCode = errorCode;
        }
    }
    public BadRequestException(string message, string? errorCode = null) : base(message)
    {
        ErrorDetails = message;

        if (errorCode != null)
        {
            ErrorCode = errorCode;
        }
    }

    public HttpStatusCode? StatusCode => HttpStatusCode.BadRequest;

    public string ErrorCode { get; private set; } = "bad_request";

    public object? ErrorDetails { get; private set; }
}
