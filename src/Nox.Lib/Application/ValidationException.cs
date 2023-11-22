using Nox.Exceptions;
using Nox.Types;
using System.Net;

namespace Nox.Application
{

    /// <summary>
    /// Commmand or Query Validation exception
    /// </summary>
    public sealed class ValidationException : Exception, IApplicationException
    {
        public ValidationException(object errorDetails) : base("Request validation exception")
        {
            ErrorDetails = errorDetails;
        }

        public HttpStatusCode? StatusCode => HttpStatusCode.BadRequest;

        public string ErrorCode => "request_validation_exception";

        public object? ErrorDetails { get; }
    }
}
