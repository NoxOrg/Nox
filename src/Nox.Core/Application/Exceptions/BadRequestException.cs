using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nox.Types;
using System.Net;

namespace Nox.Exceptions;

public class BadRequestException : Exception, IApplicationException
{
    public BadRequestException(ModelStateDictionary modelState, string? errorCode = null) : base("bad request.")
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
    public BadRequestException(ICollection<ValidationFailure> validationFailures) : base("Nox Type construction failed.")
    {
        ErrorDetails = validationFailures;
    }

    public HttpStatusCode? StatusCode => HttpStatusCode.BadRequest;

    public string ErrorCode { get; private set; } = "bad_request";

    public object? ErrorDetails { get; private set; }

    public string DisplayMessage => "Invalid request. Please check your input and try again.";

    public static void ThrowIfNotValid(ValidationResult validationResult)
    {
        if (!validationResult.IsValid)
        {
            throw new BadRequestException(validationResult.Errors);
        }
    }
}
