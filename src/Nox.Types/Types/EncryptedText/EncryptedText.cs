using System;
using Nox.Types.EncryptionText.EncryptionMethods;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="EncryptedText"/> type and value object.
/// </summary>
public sealed class EncryptedText : ValueObject<byte[], EncryptedText>
{
    public EncryptedText()
    {
        Value = new byte[] {};
    }

    /// <summary>
    /// Creates an <see cref="EncryptedText"/> from a string using the provided <paramref name="options"/>.
    /// </summary>
    /// <param name="value">Plain text to be encrypted.</param>
    /// <param name="options">Options used for encryption.</param>
    /// <returns>Encrypted text.</returns>
    /// <exception cref="TypeValidationException"></exception>
    public static EncryptedText FromPlainText(string value, EncryptedTextOptions options)
    {
        var newObject = new EncryptedText
        {
            Value = EncryptText(value, options)
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Creates an <see cref="EncryptedText"/> from an encrypted data as byte array.
    /// </summary>
    /// <param name="value">Encrypted data as byte array.</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static EncryptedText FromEncryptedText(byte[] value)
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
    /// Returns the string representation of the <see cref="EncryptText"/>.
    /// </summary>
    /// <returns>Byte array encoded as UTF-8 string.</returns>
    public override string ToString() => System.Text.Encoding.UTF8.GetString(Value);

    /// <summary>
    /// Decrypts the value using the provided algorithm options.
    /// </summary>
    /// <returns>Decrypted text representation of the <see cref="EncryptedText"/> object.</returns>
    public string ToString(EncryptedTextOptions options) => DecryptText(Value, options);

    /// <summary>
    /// Validates a <see cref="EncryptedText"/> object.
    /// </summary>
    /// <returns>true if the <see cref="EncryptedText"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = new ValidationResult();

        if (Value.Length < 1)
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox {nameof(EncryptedText)} type as an empty {nameof(Value)} is not allowed."));

        return result;
    }

    private static byte[] EncryptText(string plainText, EncryptedTextOptions encryptedTextOptions)
    {
        switch (encryptedTextOptions.EncryptionAlgorithm)
        {
            case EncryptionAlgorithm.Aes:
                return Aes.EncryptStringToBytes(plainText, encryptedTextOptions);
            default:
                throw new NotImplementedException();
        }
    }

    private static string DecryptText(byte[] encryptedText, EncryptedTextOptions encryptedTextOptions)
    {
        switch (encryptedTextOptions.EncryptionAlgorithm)
        {
            case EncryptionAlgorithm.Aes:
                return Aes.DecryptStringFromBytes(encryptedText, encryptedTextOptions);
            default:
                throw new NotImplementedException();
        }
    }
}