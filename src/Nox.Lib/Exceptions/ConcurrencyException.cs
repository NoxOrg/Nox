using System.Net;

namespace Nox.Exceptions;

public class ConcurrencyException : Exception
{
    public ConcurrencyException(string message, HttpStatusCode httpStatusCode)
        : base(message)
    {
        HttpStatusCode = httpStatusCode;
    }

    public HttpStatusCode HttpStatusCode { get; }
}