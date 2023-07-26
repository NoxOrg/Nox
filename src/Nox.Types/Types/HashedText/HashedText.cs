using System;
using System.Security.Cryptography;
using System.Text;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="HashedText"/> type and value object.
/// </summary>
public sealed class HashedText : ValueObject<(string HashText, string Salt), HashedText>
{
    /// <summary>
    /// Result of the hash operation
    /// </summary>
    public string HashText
    {
        get => Value.HashText;
        private set => Value = (HashText: value, Value.Salt);
    }

    /// <summary>
    /// Salt byte array used in the hash operation
    /// </summary>
    public string Salt
    {
        get => Value.Salt;
        private set => Value = (Value.HashText, Salt: value);
    }

    /// <summary>
    /// Base constructor for aa new empty <see cref="HashText"/> object
    /// </summary>
    public HashedText() { Value = (string.Empty, string.Empty); }

    /// <summary>
    /// Creates a new instance of <see cref="HashedText"/> object with sent <see cref="HashedTextTypeOptions"/>.
    /// </summary>
    /// <param name="plainText">Plain text that will be hashed</param>
    /// <param name="options"><see cref="HashedTextTypeOptions"/></param>
    /// <returns>New instance of <see cref="HashedText"/></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static HashedText From(string plainText, HashedTextTypeOptions options)
    {
        options ??= new HashedTextTypeOptions();

        var newObject = new HashedText() { Value = Hasher.GetHashText(plainText, options.HashingAlgorithm, options.SaltLength) };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    ///  Creates a new instance of <see cref="HashedText"/> object default <see cref="HashedTextTypeOptions"/>.
    /// </summary>
    /// <param name="plainText">Plain text that will be hashed</param>
    /// <returns>New instance of <see cref="HashedText"/></returns>
    public static HashedText From(string plainText)
        => From(plainText, new HashedTextTypeOptions());

    /// <summary>
    /// Returns string value of HashText
    /// </summary>
    public override string ToString() => $"{Value.HashText}";
}