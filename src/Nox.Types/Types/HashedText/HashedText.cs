using System;
using System.Security.Cryptography;
using System.Text;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="HashedText"/> type and value object.
/// </summary>
public sealed class HashedText : ValueObject<(string HashText, string Salt), HashedText>, IHashedText
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

    public static HashedText From(IHashedText value) 
        => throw new NotImplementedException();

    public static HashedText From(IHashedText value, HashedTextTypeOptions options)
        => throw new NotImplementedException();
    
    /// <summary>
    /// Creates a new instance of <see cref="HashedText"/> object with sent <see cref="HashedTextTypeOptions"/>.
    /// </summary>
    /// <param name="plainText">Plain text that will be hashed</param>
    /// <param name="options"><see cref="HashedTextTypeOptions"/></param>
    /// <returns>New instance of <see cref="HashedText"/></returns>
    /// <exception cref="NoxTypeValidationException"></exception>
    public static HashedText From(string plainText, HashedTextTypeOptions options)
    {
        options ??= new HashedTextTypeOptions();

        var newObject = new HashedText() { Value = Hasher.GetHashText(plainText, options.HashingAlgorithm, options.SaltLength) };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
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