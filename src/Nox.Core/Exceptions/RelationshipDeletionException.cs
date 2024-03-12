using System.Net;
using System.Runtime.Serialization;

namespace Nox.Exceptions;

[Serializable]
public class RelationshipDeletionException : Exception, IApplicationException
{
    public RelationshipDeletionException(string message)
        : base(message)
    {
    }

    public RelationshipDeletionException(string message, Exception inner)
        : base(message, inner)
    {
    }

    protected RelationshipDeletionException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public HttpStatusCode? StatusCode => HttpStatusCode.BadRequest;

    public string ErrorCode => "can_not_delete_relationship";

    public object? ErrorDetails { get; private set; }
}