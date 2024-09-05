using Nox.Types;
using System.Net;

namespace Nox.Exceptions;

public record AttributeNoxTypeValidationException(string AttributeName, IEnumerable<ValidationFailure> Errors);
/// <summary>
/// Innvalid data value provided to a nox type when creating or updating an Entity
/// </summary>
public sealed class CreateUpdateEntityInvalidDataException : Exception, IApplicationException
{
    public CreateUpdateEntityInvalidDataException(NoxTypeValidationException innerException, string attributeName) : base(innerException.Message, innerException)
    {
        ErrorDetails = new AttributeNoxTypeValidationException(attributeName ,innerException.Errors);
    }
    /// <summary>
    /// List of invalid value per attribute
    /// </summary>
    /// <param name="attributeExceptionDictionary"></param>
    public CreateUpdateEntityInvalidDataException(IReadOnlyDictionary<string, NoxTypeValidationException> attributeExceptionDictionary)
    {
        List<AttributeNoxTypeValidationException> errors = new(attributeExceptionDictionary.Count);
        foreach (var entry in attributeExceptionDictionary)
        {
            errors.Add(new (entry.Key, entry.Value.Errors));
        }
        ErrorDetails = errors.ToArray();
    }

    public HttpStatusCode? StatusCode => HttpStatusCode.BadRequest;

    public string ErrorCode => "create_update_invalid_data";

    public object? ErrorDetails { get; }

    public string DisplayMessage => "Invalid request. Please check your input and try again.";

    public static void ThrowIfAnyNoxTypeValidationException(IReadOnlyDictionary<string, NoxTypeValidationException> attributeExceptionDictionary)
    {
        if (attributeExceptionDictionary.Any())
            throw new CreateUpdateEntityInvalidDataException(attributeExceptionDictionary);
    }
}
