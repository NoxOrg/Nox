using System.Net;

namespace Nox.Exceptions;

public class RelatedEntityNotFoundException : Exception, IApplicationException
{
    public RelatedEntityNotFoundException(string relatedEntityName, string relatedEntityId)
        : this($"{relatedEntityName} with Id {relatedEntityId} was not found")
    {
        ErrorDetails = new { Entity = relatedEntityName , Key = relatedEntityId };
    }

    public RelatedEntityNotFoundException(string message)
        : base(message)
    {
        ErrorDetails = message;

    }

    public RelatedEntityNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
        ErrorDetails = message;
    }

    public HttpStatusCode? StatusCode => HttpStatusCode.BadRequest;

    public string ErrorCode => "related_entity_not_found";

    public object? ErrorDetails { get; private set; }
}