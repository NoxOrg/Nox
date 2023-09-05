using System;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Password"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class Password : ValueObject<(string HashedPassword, string Salt), Password>, IPassword
{
    /// <summary>
    /// Result of the hash operation
    /// </summary>
    public string HashedPassword
    {
        get => Value.HashedPassword;
        private set => Value = (HashedPassword: value, Value.Salt);
    }

    /// <summary>
    /// Salt byte array used in the hash operation
    /// </summary>
    public string Salt
    {
        get => Value.Salt;
        private set => Value = (Value.HashedPassword, Salt: value);
    }


    public static Password From(IPassword value) => throw new NotImplementedException();
    public static Password From(IPassword value, PasswordTypeOptions options) => throw new NotImplementedException();


    /// <summary>
    /// Creates a new instance of <see cref="Password"/> object with sent <see cref="PasswordTypeOptions"/>.
    /// </summary>
    /// <param name="value">Plain text that will be hashed</param>
    /// <param name="options"><see cref="PasswordTypeOptions"/></param>
    /// <returns>New instance of <see cref="Password"/></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Password From(string value, PasswordTypeOptions options)
    {
        var validationResult = Validate(value, options);

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        var newObject = new Password
        {
            Value = Hasher.GetHashText(value, options.HashingAlgorithm, options.SaltLength),
        };

        return newObject;
    }

    /// <summary>
    /// Creates a new instance of <see cref="Password"/> object with default <see cref="PasswordTypeOptions"/>.
    /// </summary>
    /// <param name="value">Plain text that will be hashed</param>
    /// <returns>New instance of <see cref="Password"/></returns>
    /// <exception cref="TypeValidationException"></exception>
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

        if (options.ForceSymbol && !options.PasswordContainsSymbol.IsMatch(passwordPlainText))
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
