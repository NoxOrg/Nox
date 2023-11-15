﻿using System.Security.Cryptography;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

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
}