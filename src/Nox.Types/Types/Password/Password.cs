using System.Text.RegularExpressions;
using System;
using System.Linq;
using System.ComponentModel.Design;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Password"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class Password : ValueObject<HashedText, Password>
{

    public static Password From(string value, PasswordTypeOptions options)
    {
        options ??= new PasswordTypeOptions();

        var validationResult = Validate(value, options);

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        var newObject = new Password
        {
            Value = HashedText.From(value, new HashedTextTypeOptions() { HashingAlgorithm = options.HashingAlgorithm, SaltLength = options.Salt }),
        };

        return newObject;
    }

    public static Password From(string value)
        => From(value, new PasswordTypeOptions());

    /// <summary>
    /// Validates a <see cref="Password"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Password"/> value is valid .</returns>
    internal static ValidationResult Validate(string passwordPlainText, PasswordTypeOptions options)
    {
        var result = new ValidationResult();

        if (passwordPlainText.Length < options.MinLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Password type as value length is less than than the minimum specified value of {options.MinLength}"));
        }

        if (passwordPlainText.Length > options.MaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Password type as value  length is greater than than the minimum specified value of {options.MinLength}"));
        }

        if (options.ForceUppercase && !options.PasswordContainsUpperCase.IsMatch(passwordPlainText))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Password type as value does not contain uppercase letter"));
        }

        if (options.ForceLowercase && !options.PasswordContainsLowerCase.IsMatch(passwordPlainText))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Password type as value does not contain lowercase letter"));
        }

        if (options.ForceSymbol && !options.PasswordContainsSympol.IsMatch(passwordPlainText))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Password type as value does not contain symbol"));
        }

        if (options.ForceNumber && !options.PasswordContainsNumber.IsMatch(passwordPlainText))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Password type as value does not contain number"));
        }

        return result;
    }
}
