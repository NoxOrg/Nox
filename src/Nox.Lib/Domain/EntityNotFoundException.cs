using System.Net;
using System.Runtime.Serialization;

namespace Nox.Exceptions;

[Serializable]
public class EntityNotFoundException : Exception, IApplicationException
{
    public EntityNotFoundException(string entityName, string entityId)
        : this($"{entityName} with Id {entityId} was not found")
    {
        ErrorDetails = new { Entity = entityName, Key = entityId };
    }

    public EntityNotFoundException(string message)
        : base(message)
    {
        ErrorDetails = message;

    }

    public EntityNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
        ErrorDetails = message;
    }
    protected EntityNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
    public virtual HttpStatusCode? StatusCode => HttpStatusCode.NotFound;

    public virtual  string ErrorCode => "entity_not_found";

    public object? ErrorDetails { get; private set; }
}