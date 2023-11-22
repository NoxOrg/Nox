using Nox.Exceptions;
using Nox.Types;
using System.Net;

namespace Nox.Application.Factories
{

    /// <summary>
    /// Innvalid data value provided to a nox type when creating or updating an Entity
    /// </summary>
    public sealed class CreateUpdateEntityInvalidDataException : Exception, IApplicationException
    {
        public CreateUpdateEntityInvalidDataException(NoxTypeValidationException innerException) : base(innerException.Message, innerException)
        {
            ErrorDetails = innerException.Errors;
        }

        public HttpStatusCode? StatusCode => HttpStatusCode.BadRequest;

        public string ErrorCode => "create_update_invalid_data";

        public object? ErrorDetails { get; }
    }
}
