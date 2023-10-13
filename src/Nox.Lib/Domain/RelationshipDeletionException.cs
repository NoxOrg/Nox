using System.Net;
using Nox.Types;

namespace Nox.Domain;

public class RelationshipDeletionException: Exception, INoxHttpException
{
    public RelationshipDeletionException(string message)
        : base(message)
    {
    }

    public RelationshipDeletionException(string message, Exception inner)
        : base(message, inner)
    {
    }

    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}