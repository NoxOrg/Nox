using System;
using System.Collections.Generic;

namespace Nox.Types;

public sealed class Url : ValueObject<System.Uri, Url>
{

    public static Url From(string value)
    {
        if (!System.Uri.TryCreate(value, System.UriKind.Absolute, out var uriValue))
        {
            throw new TypeValidationException(
                new List<ValidationFailure> {
                    new ValidationFailure("Uri", $"The string '{value}' you provided, is not a valid Uri.") });
        }

        var newObject = new Url
        {
            Value = uriValue
        };

        return newObject;
    }

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        bool isValid = System.Uri.TryCreate(base.Value.ToString(), UriKind.Absolute, out var uriResult) &&
                (uriResult.Scheme == System.Uri.UriSchemeHttps
                    || uriResult.Scheme == System.Uri.UriSchemeHttp
                    || uriResult.Scheme == System.Uri.UriSchemeMailto
                    || uriResult.Scheme == System.Uri.UriSchemeFtp
                    || uriResult.Scheme == System.Uri.UriSchemeFile);

        if (!isValid)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Url type; as value {Value} is not a valid Url."));
        }

        return result;
    }
}