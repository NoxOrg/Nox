using System;
using System.Linq;
using Nox.Types.EncryptionText.EncryptionMethods;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="EncryptedText"/> type and value object.
/// </summary>
public sealed class EncryptedText : ValueObject<byte[], EncryptedText>
{
    public EncryptedText()
    {
        Value = new byte[] { };
    }

    /// <summary>
    /// <see cref="EncryptedText"/> object can only be created from a byte array with <see cref="ValueObject{T,TValueObject}.FromDatabase"/>.
    /// </summary>
    public new static EncryptedText From(byte[] _) =>
        throw new InvalidOperationException($"{nameof(EncryptedText)} can only be created with {nameof(FromDatabase)}.");

    /// <summary>
    /// Creates an <see cref="EncryptedText"/> from a string using the provided <paramref name="typeOptions"/>.
    /// </summary>
    /// <param name="value">Plain text to be encrypted.</param>
    /// <param name="typeOptions">Options used for encryption.</param>
    /// <returns>Encrypted text.</returns>
    /// <exception cref="NoxTypeValidationException"></exception>
    public static EncryptedText FromPlainText(string value, EncryptedTextTypeOptions typeOptions)
    {
        var newObject = new EncryptedText
        {
            Value = EncryptText(value, typeOptions)
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
        }

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
        if (obj is EncryptedText encryptedText)
            return Value.SequenceEqual(encryptedText.Value);

        return false;
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

    private static byte[] EncryptText(string plainText, EncryptedTextTypeOptions encryptedTextTypeOptions)
    {
        switch (encryptedTextTypeOptions.EncryptionAlgorithm)
        {
            case EncryptionAlgorithm.Aes:
                return Aes.EncryptStringToBytes(plainText, encryptedTextTypeOptions);
            default:
                throw new NotImplementedException();
        }
    }

    private static string DecryptText(byte[] encryptedText, EncryptedTextTypeOptions encryptedTextTypeOptions)
    {
        switch (encryptedTextTypeOptions.EncryptionAlgorithm)
        {
            case EncryptionAlgorithm.Aes:
                return Aes.DecryptStringFromBytes(encryptedText, encryptedTextTypeOptions);
            default:
                throw new NotImplementedException();
        }
    }
}