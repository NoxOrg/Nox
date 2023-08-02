using System;
using System.Collections.Generic;

namespace Nox.Types;

public sealed class Url : ValueObject<System.Uri, Url>
{
    private static readonly List<string> ValidSchemes = new()
    {
        System.Uri.UriSchemeHttps,
        System.Uri.UriSchemeHttp,
        System.Uri.UriSchemeMailto,
        System.Uri.UriSchemeFtp,
        System.Uri.UriSchemeFile
    };

    public static Url From(string value)
    {
        if (!System.Uri.TryCreate(value, UriKind.Absolute, out var uriValue))
        {
            throw new TypeValidationException(
                new List<ValidationFailure> { new(nameof(value), $"The string '{value}' you provided, is not a valid Uri.") }
            );
        }

        var newObject = new Url { Value = uriValue };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <inheritdoc />
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        bool isValid = System.Uri.TryCreate(Value.ToString(), UriKind.Absolute, out var uriResult) && ValidSchemes.Contains(uriResult.Scheme);

        if (!isValid)
        {
            result.Errors.Add(new ValidationFailure(
                nameof(Value), $"Could not create a Nox Url type; as value {Value} is not a valid Url.")
            );
        }

        return result;
    }
}