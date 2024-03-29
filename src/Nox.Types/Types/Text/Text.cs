﻿using System;
using System.Linq;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Text"/> type and value object. 
/// </summary>
public sealed class Text : ValueObject<string, Text>
{
    private TextTypeOptions _typeOptions = new();

    public Text() { Value = string.Empty; }

    /// <summary>
    /// Creates a new instance of <see cref="Text"/> using the specified <see cref="TextTypeOptions"/>
    /// </summary>
    /// <param name="value">The string to create the <see cref="Text"/> with</param>
    /// <param name="options">The <see cref="TextTypeOptions"/> containing constraints for the value object</param>
    /// <returns></returns>
    /// <exception cref="ValidationException">If the email address is invalid.</exception>
    public static Text From(string value, TextTypeOptions options)
    {
        var newObject = new Text
        {
            Value = value,
            _typeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="Text"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Text"/> value is valid according to the default or specified <see cref="TextTypeOptions"/>.</returns>
    /// <exception cref="NotImplementedException">If the <see cref="TextTypeCasing"/> is not implemented by this method.</exception>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value.Length < _typeOptions.MinLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Text type that is {Value.Length} characters long and shorter than the minimum specified length of {_typeOptions.MinLength}"));
        }

        if (Value.Length > _typeOptions.MaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Text type that is {Value.Length} characters long and longer than the maximum specified length of {_typeOptions.MaxLength}"));
        }

        if (!_typeOptions.IsUnicode && Value.Any(c => c > 255))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a non-UniCode Nox Text type that contains Unicode characters '{new string(Value.Where(c => c > 255).ToArray())}'"));
        }

        if (_typeOptions.Casing != TextTypeCasing.Normal)
        {
            Value = _typeOptions.Casing switch
            {
                TextTypeCasing.Upper => Value.ToUpperInvariant(),
                TextTypeCasing.Lower => Value.ToLowerInvariant(),
                _ => throw new NotImplementedException(),
            };
        }

        return result;
    }
    
    public override string ToString()
    {
        return Value;
    }

    //public bool Equals(Text? other)
    //{
    //    if (other == null) return false;
    //    return Value.Equals(other.Value);
    //}

    //public override bool Equals(object? obj)
    //{
    //    return ReferenceEquals(this, obj) || obj is Text other && Equals(other);
    //}
    //public override int GetHashCode() => Value.GetHashCode();
}
