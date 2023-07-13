using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Html"/> type and value object.
/// </summary>
public sealed class Html : ValueObject<string, Html>
{
    public new static Html From(string value)
    {
        var newObject = new Html
        {
            Value = value
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="Html"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Html"/> value is valid .</returns>
    internal override ValidationResult Validate()
    {
        bool ContainsTag(string value, string tagName)
        {
            return Regex.IsMatch(value, $@"<{tagName}\s*>", RegexOptions.IgnoreCase) // opening tag
                && Regex.IsMatch(value, $@"</{tagName}\s*>", RegexOptions.IgnoreCase); // closing tag
        }

        var result = base.Validate();

        if (!ContainsTag(Value, "html"))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                "A Nox Html type requires opening and closing 'html' tags to be valid."));
        }

        return result;
    }
}