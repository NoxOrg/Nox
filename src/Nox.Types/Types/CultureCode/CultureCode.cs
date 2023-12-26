using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Nox.Yaml.Attributes;
using Nox.Yaml.Enums.CultureCode;

namespace Nox.Types;

/// <summary>
/// Represents a culture value object that encapsulates culture-related information.
/// </summary>
public partial class CultureCode : ValueObject<string, CultureCode>
{
    private static readonly ImmutableHashSet<string> SupportedCultureCodes = System.Enum.GetValues(typeof(Culture)).Cast<Culture>().Select(v =>
    {
        var field =  v.GetType().GetField(v.ToString())!;
        var attribute = field.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault() as DisplayNameAttribute;
        return attribute?.DisplayName ?? v.ToString();
    }).ToImmutableHashSet();
    
    /// <summary>
    /// Validates the <see cref="CultureCode"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="CultureCode"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!SupportedCultureCodes.Contains(Value))
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
       
        var field =  value.GetType().GetField(value.ToString());
        DisplayNameAttribute? attribute = null;
        if(field is not null)
        {
            attribute = field.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault() as DisplayNameAttribute;
        }
        var cultureCode = attribute?.DisplayName ?? value.ToString();
        var newObject = new CultureCode
        {
            Value = cultureCode
        };
        
        var validationResult = newObject.Validate();
        
        if(!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
        }

        return newObject;
    }
}