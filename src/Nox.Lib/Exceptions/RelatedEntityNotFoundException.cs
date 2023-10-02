namespace Nox.Exceptions;

public class RelatedEntityNotFoundException : Exception
{
    public RelatedEntityNotFoundException(string relatedEntityName, string relatedEntityId) 
        : this($"{relatedEntityName} with Id {relatedEntityId} was not found")
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
}
