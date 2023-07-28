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
    /// <param name="typeOptions">Algorithm options.</param>
    /// <returns>Encrypted text as a byte array.</returns>
    public static byte[] EncryptStringToBytes(string plainText, EncryptedTextTypeOptions typeOptions)
    {
        if (string.IsNullOrEmpty(plainText))
            throw new ArgumentNullException(nameof(plainText));
        if (typeOptions.PublicKey is not { Length: > 0 })
            throw new ArgumentNullException(nameof(typeOptions.PublicKey));
        if (typeOptions.Iv is not { Length: > 0 })
            throw new ArgumentNullException(nameof(typeOptions.Iv));

        using AesAlg aesAlg = AesAlg.Create();

        // Create a Crypto object with the specified key and IV.
        using ICryptoTransform encryptor = aesAlg.CreateEncryptor(
            Convert.FromBase64String(typeOptions.PublicKey),
            Convert.FromBase64String(typeOptions.Iv)
        );

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
    /// <param name="encryptedText">Encrypted text as a byte array.</param>
    /// <param name="typeOptions">Algorithm options.</param>
    /// <returns>Decrypted text.</returns>
    public static string DecryptStringFromBytes(byte[] encryptedText, EncryptedTextTypeOptions typeOptions)
    {
        if (encryptedText is not { Length: > 0 })
            throw new ArgumentNullException(nameof(encryptedText));
        if (typeOptions.PublicKey is not { Length: > 0 })
            throw new ArgumentNullException(nameof(typeOptions.PublicKey));
        if (typeOptions.Iv is not { Length: > 0 })
            throw new ArgumentNullException(nameof(typeOptions.Iv));

        using AesAlg aesAlg = AesAlg.Create();

        // Create an Aes object with the specified Key and IV.
        ICryptoTransform decryptor = aesAlg.CreateDecryptor(
            Convert.FromBase64String(typeOptions.PublicKey),
            Convert.FromBase64String(typeOptions.Iv)
        );

        // Create the streams used for decryption.
        using MemoryStream msDecrypt = new MemoryStream(encryptedText);
        using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new StreamReader(csDecrypt);
        // Read the decrypted bytes from the decrypting stream and place them in a string.
        string resultText = srDecrypt.ReadToEnd();

        return resultText;
    }
}