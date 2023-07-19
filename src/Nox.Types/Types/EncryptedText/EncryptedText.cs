using System;
using System.Linq;
using Nox.Types.EncryptionText.EncryptionMethods;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="EncryptedText"/> type and value object.
/// </summary>
public sealed class EncryptedText : ValueObject<string, EncryptedText>
{
    public EncryptedText()
    {
        Value = "";
    }

    /// <inheritdoc cref="FromEncryptedString"/>
    public new static EncryptedText From(string value) => FromEncryptedString(value);

    /// <summary>
    /// Creates an <see cref="EncryptedText"/> from a string using the provided <paramref name="typeOptions"/>.
    /// </summary>
    /// <param name="value">Plain text to be encrypted.</param>
    /// <param name="typeOptions">Options used for encryption.</param>
    /// <returns>Encrypted text.</returns>
    /// <exception cref="TypeValidationException"></exception>
    public static EncryptedText FromPlainText(string value, EncryptedTextTypeOptions typeOptions)
    {
        var newObject = new EncryptedText
        {
            Value = EncryptText(value, typeOptions)
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Creates an <see cref="EncryptedText"/> from encrypted data as base64 string.
    /// </summary>
    /// <param name="value">Encrypted data as base64 string.</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static EncryptedText FromEncryptedString(string value)
    {
        var newObject = new EncryptedText
        {
            Value = value
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
            throw new TypeValidationException(validationResult.Errors);

        return newObject;
    }

    /// <summary>
    /// Decrypts the value using the provided algorithm options.
    /// </summary>
    /// <returns>Decrypted text representation of the <see cref="EncryptedText"/> object.</returns>
    public string DecryptText(EncryptedTextTypeOptions typeOptions) => DecryptText(Value, typeOptions);

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        return Value.SequenceEqual(((EncryptedText)obj).Value);
    }

    /// <inheritdoc />
    public override int GetHashCode() => base.GetHashCode();

    /// <summary>
    /// Validates a <see cref="EncryptedText"/> object.
    /// </summary>
    /// <returns>true if the <see cref="EncryptedText"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value.Length < 1)
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox {nameof(EncryptedText)} type as an empty {nameof(Value)} is not allowed."));

        return result;
    }

    private static string EncryptText(string plainText, EncryptedTextTypeOptions encryptedTextTypeOptions)
    {
        switch (encryptedTextTypeOptions.EncryptionAlgorithm)
        {
            case EncryptionAlgorithm.Aes:
                return Aes.EncryptStringToBase64(plainText, encryptedTextTypeOptions);
            default:
                throw new NotImplementedException();
        }
    }

    private static string DecryptText(string encryptedText, EncryptedTextTypeOptions encryptedTextTypeOptions)
    {
        switch (encryptedTextTypeOptions.EncryptionAlgorithm)
        {
            case EncryptionAlgorithm.Aes:
                return Aes.DecryptStringFromBase64(encryptedText, encryptedTextTypeOptions);
            default:
                throw new NotImplementedException();
        }
    }
}