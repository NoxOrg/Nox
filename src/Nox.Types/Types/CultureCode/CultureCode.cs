using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a culture value object that encapsulates culture-related information.
/// </summary>
public partial class CultureCode : ValueObject<string, CultureCode>
{
    /// <summary>
    /// The culture code.
    /// </summary>
    private const string _twoLettersCultureCode = @"^[a-z]{2}$";

    /// <summary>
    /// The culture code.
    /// </summary>
    private const string _fiveLettersCultureCode = @"^[a-z]{2}-[A-Z]{2}$";

    /// <summary>
    /// The culture code.
    /// </summary>
    private const string _tenLettersCultureCode = @"^[a-z]{2}-[A-Z]{2}-[A-Z][a-z]{3}$";

    /// <summary>
    /// Validates the <see cref="CultureCode"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="CultureCode"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!CultureCodeRegex2().IsMatch(Value)
            && !CultureCCodeRegex2_2().IsMatch(Value)
            && !CultureCCodeRegex2_2_3().IsMatch(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox CultureCode type with unsupported value '{Value}'."));
        }

        return result;
    }

    [GeneratedRegex("^[a-z]{2}$")]
    private static partial Regex CultureCodeRegex2();

    [GeneratedRegex("^[a-z]{2}-[A-Z]{2}$")]
    private static partial Regex CultureCCodeRegex2_2();

    [GeneratedRegex("^[a-z]{2}-[A-Z]{2}-[A-Z][a-z]{3}$")]
    private static partial Regex CultureCCodeRegex2_2_3();

}