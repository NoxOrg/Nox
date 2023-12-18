namespace Nox.Exceptions;

/// <summary>
/// trying to set a null to a non nullable property
/// </summary>
public class EntityAttributeIsNotNullableException : Exception
{
    public EntityAttributeIsNotNullableException(string entityName, string attributeName): this($"{entityName} {attributeName} is not nullable")
    {
    }

    public EntityAttributeIsNotNullableException(string message)
        : base(message)
    {
    }

    public EntityAttributeIsNotNullableException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
