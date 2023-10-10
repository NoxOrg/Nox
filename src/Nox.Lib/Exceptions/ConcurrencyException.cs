using System.Net;
using Nox.Types;

namespace Nox.Exceptions;

public class ConcurrencyException : Exception, INoxHttpException
{
    public ConcurrencyException(string message, HttpStatusCode statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public HttpStatusCode StatusCode { get; }
}