using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Text"/> type and value object. 
/// </summary>
public sealed class Enumeration : ValueObject<int, Enumeration>
{
    private EnumerationTypeOptions _typeOptions = new();

    public static new Enumeration From(int value)
    {
        throw new NotImplementedException("An Enumeration object requires EnumerationTypeOptions. Use From(int value, EnumerationTypeOptions options).");
    }


    /// <summary>
    /// Creates a new instance of <see cref="Enumeration"/> using the specified <see cref="EnumerationTypeOptions"/>
    /// </summary>
    /// <param name="value">The Enum integer value to create the <see cref="Text"/> with</param>
    /// <param name="options">The <see cref="EnumerationTypeOptions"/> containing constraints for the value object</param>
    /// <returns>A new <see cref="Enumeration" instance./></returns>
    /// <exception cref="ValidationException">If the enum value is invalid.</exception>
    public static Enumeration From(int value, EnumerationTypeOptions options)
    {
        var newObject = new Enumeration
        {
            Value = value,
            _typeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Creates a new instance of <see cref="Enumeration"/> using the specified <see cref="EnumerationTypeOptions"/>
    /// </summary>
    /// <param name="value">The Enum integer value to create the <see cref="Text"/> with</param>
    /// <param name="options">The <see cref="EnumerationTypeOptions"/> containing constraints for the value object</param>
    /// <returns>A new <see cref="Enumeration" instance./></returns>
    /// <exception cref="ValidationException">If the enum value is invalid.</exception>
    public static Enumeration From(string stringValue, EnumerationTypeOptions options)
    {

        var value = options.Values?.FirstOrDefault(o => o.Description.Equals(stringValue, StringComparison.InvariantCultureIgnoreCase))?.Id;  

        if (value is null)
        {
            var result = new ValidationResult();
            result.Errors.Add(new ValidationFailure(nameof(Value), $"No enumerator exists with an Description of '{stringValue}'."));

            throw new TypeValidationException(result.Errors);
        }

        return From((int)value, options);
    }


    /// <summary>
    /// Validates a <see cref="Enumeration"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Enumeration"/> value is valid according to the default or specified <see cref="EnumerationTypeOptions"/>.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (_typeOptions?.Values?.FirstOrDefault(o => o.Id == Value) == null)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"No enumerator exists with an Id of '{Value}'"));
        }

        return result;
    }

    public override string ToString()
    {
        return _typeOptions?.Values?.FirstOrDefault(o => o.Id == Value)?.Description ?? string.Empty;
    }

    public IDictionary<int,string>? GetValues()
    {
        return _typeOptions?.Values?.ToDictionary( o => o.Id, o => o.Description );
    }

}
