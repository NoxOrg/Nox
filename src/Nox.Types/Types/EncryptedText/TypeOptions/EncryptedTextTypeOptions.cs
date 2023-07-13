using System.Security.Cryptography;

namespace Nox.Types;

public class EncryptedTextTypeOptions
{
    public EncryptionAlgorithm EncryptionAlgorithm { get; set; } = EncryptionAlgorithm.Aes;

    /// <summary>
    /// The secret key to use for the algorithm.
    /// </summary>
    public byte[]? PublicKey { get; set; }

    /// <summary>
    /// The initialization vector.
    /// <seealso cref="SymmetricAlgorithm.IV"/>
    /// </summary>
    public byte[]? Iv { get; set; }
}