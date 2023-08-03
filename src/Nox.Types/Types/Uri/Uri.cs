using System.Collections.Generic;

namespace Nox.Types;

public sealed class Uri : ValueObject<System.Uri, Uri> 
{

    public static Uri From(string value)
        => From(value, System.UriKind.Absolute);

    public static Uri From(string value, System.UriKind uriKind = System.UriKind.Absolute)
    {
        if (!System.Uri.TryCreate(value, uriKind, out var uriValue))
        {
            throw new TypeValidationException(
                new List<ValidationFailure> {
                    new ValidationFailure("Uri", $"The string '{value}' you provided, is not a valid Uri.") });
        }

        var newObject = new Uri
        {
            Value = uriValue
        };

        return newObject;
    }

    public static Uri FromDatabase(string value)
    {
        return  new Uri
        {
            Value = new System.Uri(value, System.UriKind.Absolute)
        };
    }

}