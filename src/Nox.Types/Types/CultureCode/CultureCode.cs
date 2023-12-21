using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a culture value object that encapsulates culture-related information.
/// </summary>
public partial class CultureCode : ValueObject<string, CultureCode>
{
    /// <summary>
    /// Validates the <see cref="CultureCode"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="CultureCode"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!CultureCodeRegex().IsMatch(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox CultureCode type with unsupported value '{Value}'."));
        }

        return result;
    }

    [GeneratedRegex(Nox.Types.Abstractions.CultureCode.RegularExpression)]
    private static partial Regex CultureCodeRegex();
}