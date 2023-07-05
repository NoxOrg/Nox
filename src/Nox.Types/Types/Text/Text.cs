using System;
using System.Linq;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Text"/> type and value object. 
/// </summary>
public sealed class Text : ValueObject<string,Text>
{
    private TextTypeOptions _textTypeOptions = new();

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
            _textTypeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
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

        if (Value.Length < _textTypeOptions.MinLength)
        {
            result.Errors.Add( new ValidationFailure(nameof(Value), $"Could not create a Nox Text type that is {Value.Length} characters long and shorter than the minimum specified length of {_textTypeOptions.MinLength}"));
        }

        if (Value.Length > _textTypeOptions.MaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Text type that is {Value.Length} characters long and longer than the maximum specified length of {_textTypeOptions.MaxLength}"));
        }

        if (!_textTypeOptions.IsUnicode && Value.Any(c => c > 255))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a non-UniCode Nox Text type that contains Unicode characters '{new string(Value.Where(c => c > 255).ToArray())}'"));
        }

        if (_textTypeOptions.Casing != TextTypeCasing.Normal)
        {
            Value = _textTypeOptions.Casing switch
            {
                TextTypeCasing.Upper => Value.ToUpperInvariant(),
                TextTypeCasing.Lower => Value.ToLowerInvariant(),
                _ => throw new NotImplementedException(),
            };
        }

        return result;
    }

}
