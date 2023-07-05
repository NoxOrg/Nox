using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a culture value object that encapsulates culture-related information.
/// </summary>
public class CultureCode : ValueObject<string, CultureCode>
{
    private const string TwoLettersCultureCode = @"^[a-z]{2}$";
    private const string FiveLettersCultureCode = @"^[a-z]{2}-[A-Z]{2}$";
    private const string TenLettersCultureCode = @"^[a-z]{2}-[A-Z]{2}-[A-Z][a-z]{3}$";

    /// <summary>
    /// Validates the <see cref="CultureCode"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="CultureCode"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();
        
        if (!Regex.IsMatch(Value, TwoLettersCultureCode) && !Regex.IsMatch(Value, FiveLettersCultureCode) && !Regex.IsMatch(Value, TenLettersCultureCode))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox CultureCode type with unsupported value '{Value}'."));
        }

        return result;
    }

   
}
