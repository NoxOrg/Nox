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

        var newObject = GetHashText(plainText, options);

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

    /// <summary>
    /// Creates hashed value of plainText using HashedTextTypeOptions
    /// </summary>
    /// <param name="plainText">Plain text that will be hashed</param>
    /// <param name="options"><see cref="HashedTextTypeOptions"/></param>
    /// <returns>Hashed value of plainText</returns>
    private static HashedText GetHashText(string plainText, HashedTextTypeOptions options)
    {
        string hashedText = string.Empty;
        string salt = string.Empty;

        using (var hasher = CreateHasher(options.HashingAlgorithm))
        {
            byte[] saltBytes = GetSalt(options.SaltLength);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            AppendBytes(ref plainTextBytes, saltBytes);
            byte[] hashBytes = hasher.ComputeHash(plainTextBytes);

            hashedText = Convert.ToBase64String(hashBytes);
            salt = Convert.ToBase64String(saltBytes);
        }

        return new HashedText { Value = (hashedText, salt) };
    }

    /// <summary>
    /// Returns hasher with sent algorithm
    /// </summary>
    /// <param name="hashAlgorithm"></param>
    /// <returns></returns>
    /// <exception cref="CryptographicException"></exception>
    private static HashAlgorithm CreateHasher(HashingAlgorithm hashAlgorithm)
    {
        HashAlgorithm hasher = HashAlgorithm.Create(hashAlgorithm.ToString());

        return hasher ?? throw new CryptographicException("Invalid hash algorithm");
    }

    /// <summary>
    /// Creates salt byte array with length byteCount
    /// </summary>
    /// <param name="byteCount">array length</param>
    /// <returns></returns>
    private static byte[] GetSalt(int byteCount)
    {
        byte[] salt = new byte[byteCount];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);

        return salt;
    }

    /// <summary>
    /// Merges two byte arrays
    /// </summary>
    /// <param name="target">array to be appended</param>
    /// <param name="source">array to be added on target</param>
    private static void AppendBytes(ref byte[] target, byte[] source)
    {
        int targetLength = target.Length;
        int sourceLength = source.Length;
        if (sourceLength != 0)
        {
            Array.Resize(ref target, targetLength + sourceLength);
            Array.Copy(source, 0, target, targetLength, sourceLength);
        }
    }
}