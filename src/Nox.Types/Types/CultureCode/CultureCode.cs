using Nox.Types.Abstractions.Extensions;

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

        if(!Abstractions.CultureCode.CultureCodeDisplayNames.TryGetValue(Value, out _))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox CultureCode type with unsupported value '{Value}'."));
        }

        return result;
    }
    
    /// <summary>
    /// Creates a new instance of <see cref="CultureCode"/>
    /// <param name="value">The Culture value type of <see cref="Culture"/> to create the <see cref="CultureCode"/> with</param>
    /// </summary>
    /// <returns>A new instance of <see cref="CultureCode"/></returns>
    public static CultureCode From(Culture value)
    {
        var newObject = new CultureCode
        {
            Value = value.ToDisplayName()
        };
        
        var validationResult = newObject.Validate();
        
        if(!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
        }

        return newObject;
    }
}