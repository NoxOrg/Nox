using System.Net;

namespace Nox.Exceptions;

public sealed class ConcurrencyException : System.Exception, IApplicationException
{
    public ConcurrencyException(string message, HttpStatusCode statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public HttpStatusCode? StatusCode { get; }

    public string ErrorCode => "etag_invalid";

    public object? ErrorDetails => Message;
}
