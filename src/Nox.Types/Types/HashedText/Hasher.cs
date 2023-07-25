
using System;
using System.Security.Cryptography;
using System.Text;

namespace Nox.Types;
public static class Hasher
{
    /// <summary>
    /// Creates hashed value of plainText using HashedTextTypeOptions
    /// </summary>
    /// <param name="plainText">Plain text that will be hashed</param>
    /// <param name="options"><see cref="HashedTextTypeOptions"/></param>
    /// <returns>Hashed value of plainText</returns>
    public static (string, string) GetHashText(string plainText, HashingAlgorithm hashingAlgorithm, int saltLength)
    {
        string hashedText = string.Empty;
        string salt = string.Empty;

        using (var hasher = CreateHasher(hashingAlgorithm))
        {
            byte[] saltBytes = GetSalt(saltLength);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            AppendBytes(ref plainTextBytes, saltBytes);
            byte[] hashBytes = hasher.ComputeHash(plainTextBytes);

            hashedText = Convert.ToBase64String(hashBytes);
            salt = Convert.ToBase64String(saltBytes);
        }

        return (hashedText, salt);
    }

    /// <summary>
    /// Returns hasher with sent algorithm
    /// </summary>
    /// <param name="hashAlgorithm"></param>
    /// <returns></returns>
    /// <exception cref="CryptographicException"></exception>
    private static HashAlgorithm CreateHasher(HashingAlgorithm hashAlgorithm)
    {
        switch (hashAlgorithm)
        {
            case HashingAlgorithm.SHA256: return SHA256.Create();
            case HashingAlgorithm.SHA512: return SHA512.Create();
            default:
                break;
        }

        throw new CryptographicException("Invalid hash algorithm");
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

