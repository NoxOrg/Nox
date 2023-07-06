using System;
using System.IO;
using System.Security.Cryptography;
using AesAlg = System.Security.Cryptography.Aes;

namespace Nox.Types.EncryptionText.EncryptionMethods;

/// <summary>
/// Class used to encrypt and decrypt text using the <see cref="System.Security.Cryptography.Aes"/> encryption method.
/// </summary>
public static class Aes
{
    /// <summary>
    /// Encrypt text using AES algorithm.
    /// </summary>
    /// <param name="plainText">Text to be encrypted</param>
    /// <param name="options">Algorithm options.</param>
    /// <returns>Encrypted text as a byte array.</returns>
    public static byte[] EncryptStringToBytes(string plainText, EncryptedTextOptions options)
    {
        if (string.IsNullOrEmpty(plainText))
            throw new ArgumentNullException(nameof(plainText));
        if (options.PublicKey is not { Length: > 0 })
            throw new ArgumentNullException(nameof(options.PublicKey));
        if (options.Iv is not { Length: > 0 })
            throw new ArgumentNullException(nameof(options.Iv));

        using AesAlg aesAlg = AesAlg.Create();

        // Create a Crypto object with the specified key and IV.
        using ICryptoTransform encryptor = aesAlg.CreateEncryptor(options.PublicKey, options.Iv);

        // Create the streams used for decryption.
        using MemoryStream msEncrypt = new MemoryStream();
        using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
        {
            swEncrypt.Write(plainText);
        }
        return msEncrypt.ToArray();
    }

    /// <summary>
    /// Decrypt text using AES algorithm.
    /// </summary>
    /// <param name="encryptedText">Encrypted text as byte array.</param>
    /// <param name="options">Algorithm options.</param>
    /// <returns>Decrypted text.</returns>
    public static string DecryptStringFromBytes(byte[] encryptedText, EncryptedTextOptions options)
    {
        if (encryptedText is not { Length: > 0 })
            throw new ArgumentNullException(nameof(encryptedText));
        if (options.PublicKey is not { Length: > 0 })
            throw new ArgumentNullException(nameof(options.PublicKey));
        if (options.Iv is not { Length: > 0 })
            throw new ArgumentNullException(nameof(options.Iv));

        using AesAlg aesAlg = AesAlg.Create();

        // Create an Aes object with the specified Key and IV.
        ICryptoTransform decryptor = aesAlg.CreateDecryptor(options.PublicKey, options.Iv);

        // Create the streams used for decryption.
        using MemoryStream msDecrypt = new MemoryStream(encryptedText);
        using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new StreamReader(csDecrypt);
        // Read the decrypted bytes from the decrypting stream and place them in a string.
        string resultText = srDecrypt.ReadToEnd();

        return resultText;
    }
}