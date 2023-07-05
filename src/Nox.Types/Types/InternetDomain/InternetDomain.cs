using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="InternetDomain"/> type and value object.
/// </summary>
public sealed class InternetDomain : ValueObject<string, InternetDomain>
{
    private const string InternetDomainPattern = @"^(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$";

    /// <summary>
    /// Validates the <see cref="InternetDomain"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="InternetDomain"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (string.IsNullOrEmpty(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), "Could not create a Nox InternetDomain type with an empty value."));
        }
        else if (!Regex.IsMatch(Value, InternetDomainPattern))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox InternetDomain type with unsupported value '{Value}'."));
        }

        return result;
    }
}
