using System.Runtime.Serialization;

namespace Nox.Exceptions;

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

    public override string DisplayMessage => "Related entity was not found.";

    public override string ErrorCode => "related_entity_not_found";
}