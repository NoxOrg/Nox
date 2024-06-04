using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Nox.Exceptions;

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

    public virtual HttpStatusCode? StatusCode => HttpStatusCode.NotFound;

    public virtual string ErrorCode => "entity_not_found";

    public object? ErrorDetails { get; private set; }

    public static void ThrowIfNull([NotNull] object? argument, string entityName, string entityId)
    {
        if (argument is null)
        {
            throw new EntityNotFoundException(entityName, entityId);
        }
    }
}