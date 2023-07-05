
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Email"/> type and value object. 
/// </summary>
public sealed class Email : ValueObject<string, Email>
{
    private static readonly Regex _emailRegex = new(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", RegexOptions.Compiled, new TimeSpan(0, 0, 1));

    private static readonly Regex _nameAndEmailRegex = new(@"^(.+)\s+<(.+)>$", RegexOptions.Compiled, new TimeSpan(0, 0, 1));

    private string _namePartIfProvided = string.Empty;

    public static readonly Email Unknown = new() { Value = "?" };

    new public static Email From(string value)
    {
        var namePartIfProvided = string.Empty;

        value = value.Trim();

        if (_nameAndEmailRegex.IsMatch(value))
        {
            var parts = _nameAndEmailRegex.Split(value);
            if (parts.Length > 2)
            {
               value = parts[2];
               namePartIfProvided = parts[1];
            }
        }

        var newObject = new Email
        {
            Value = value,
            _namePartIfProvided = namePartIfProvided,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new  TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="Email"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Email"/> value is valid .</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!_emailRegex.IsMatch(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Email type with invalid value '{Value}'."));
        }

        return result;
    }

    // Email addresses are case insensitive so we always compare with invariant lower case
    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), Value.ToLowerInvariant());
    }

    public string GetUser() => Value.Substring(0, Value.IndexOf("@"));
    public string GetDomain() => Value.Substring(Value.IndexOf("@")+1);
    public string GetName() => _namePartIfProvided;

}
