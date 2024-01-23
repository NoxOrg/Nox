using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.Serialization;

namespace Nox.Exceptions;

[Serializable]
public class EntityLocalizationNotFoundException : Exception, IApplicationException
{
    public EntityLocalizationNotFoundException(string entityName, string entityId, string cultureCode)
        : this($"Localization for {entityName} with Id {entityId} for Culture Code {cultureCode} was not found")
    {
        ErrorDetails = new { Entity = entityName, Key = entityId, CultureCode = cultureCode };
    }

    public EntityLocalizationNotFoundException(string message)
        : base(message)
    {
        ErrorDetails = message;
    }

    public EntityLocalizationNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
        ErrorDetails = message;
    }
    protected EntityLocalizationNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public virtual HttpStatusCode? StatusCode => HttpStatusCode.NotFound;

    public virtual string ErrorCode => "entity_localization_not_found";

    public object? ErrorDetails { get; private set; }

    public static void ThrowIfNull([NotNull] object? argument, string entityName, string entityId, string cultureCode)
    {
        if (argument is null)
        {
            throw new EntityLocalizationNotFoundException(entityName, entityId, cultureCode);
        }
    }
}
