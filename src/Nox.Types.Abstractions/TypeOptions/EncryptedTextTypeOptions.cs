using System.Security.Cryptography;

namespace Nox.Types;

public class EncryptedTextTypeOptions : INoxTypeOptions
{
    public EncryptionAlgorithm EncryptionAlgorithm { get; set; } = EncryptionAlgorithm.Aes;

    /// <summary>
    /// The secret key to use for the algorithm as a base64 string.
    /// </summary>
    public string? PublicKey { get; set; }

    /// <summary>
    /// The initialization vector as a base64 string.
    /// <seealso cref="SymmetricAlgorithm.IV"/>
    /// </summary>
    public string? Iv { get; set; }

    /// <summary>
    /// Minimum Length for the DatabaseConfigurator.
    /// </summary>
    public uint MinLength { get; set; } = 0;

    /// <summary>
    /// Maximum Length for the DatabaseConfigurator.
    /// </summary>
    public uint MaxLength { get; set; } = 255;
}