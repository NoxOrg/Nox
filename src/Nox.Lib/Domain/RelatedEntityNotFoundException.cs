using System.Net;
using System.Runtime.Serialization;

namespace Nox.Exceptions;

[Serializable]
public class RelatedEntityNotFoundException : EntityNotFoundException, IApplicationException
{
    public RelatedEntityNotFoundException(string entityName, string entityId)
        : base(entityName, entityId)
    {
    }

    public RelatedEntityNotFoundException(string message)
        : base(message)
    {
    }

    public RelatedEntityNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
    protected RelatedEntityNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
    public override string ErrorCode => "related_entity_not_found";

}