// ReSharper disable once CheckNamespace

using System.Security.Cryptography;
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class EncryptedTextTests
{
    private readonly EncryptedTextOptions _options;
    private const string PlainText = "plain text";

    public EncryptedTextTests()
    {
        var aesAlg = Aes.Create();

        _options = new EncryptedTextOptions
        {
            PublicKey = aesAlg.Key,
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            Iv = aesAlg.IV
        };
    }

    [Fact]
    public void Constructor_ReturnsEncryptedValue()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _options);

        encryptedText.Should().NotBeNull();
        encryptedText.Value.Should().NotBeNull().And.NotBeEmpty();
    }

    [Fact]
    public void Decryption_ReturnsOriginalValue()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _options);
        var decryptedText = encryptedText.ToString(_options);

        PlainText.Should().Be(decryptedText);
    }

    [Fact]
    public void SameEncryptParameters_Returns_SameEncryptedValue()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _options);
        var encryptedText2 = EncryptedText.FromPlainText(PlainText, _options);

        encryptedText.Should().NotBeNull();
        encryptedText2.Should().NotBeNull();
        encryptedText.Value.Should().Equal(encryptedText2.Value);
    }

    [Fact]
    public void DifferentEncryptParameters_Returns_DifferentEncryptedValue()
    {
        var aesAlg = Aes.Create();

        // Change key
        aesAlg.GenerateKey();
        var encryptOptions1 = new EncryptedTextOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = aesAlg.Key,
            Iv = aesAlg.IV
        };

        // Change IV
        aesAlg.GenerateIV();
        var encryptOptions2 = new EncryptedTextOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = aesAlg.Key,
            Iv = aesAlg.IV
        };

        var encryptedText = EncryptedText.FromPlainText(PlainText, _options);
        // Different key
        var encryptedText1 = EncryptedText.FromPlainText(PlainText, encryptOptions1);
        // Different IV
        var encryptedText2 = EncryptedText.FromPlainText(PlainText, encryptOptions2);

        encryptedText.Value.Should().NotEqual(encryptedText1.Value);
        encryptedText1.Value.Should().NotEqual(encryptedText2.Value);
    }

    [Fact]
    public void Decryption_With_DifferentOptions_ThrowsCryptographicException()
    {
        var aesAlg = Aes.Create();

        var encryptedText = EncryptedText.FromPlainText(PlainText, _options);

        aesAlg.GenerateKey();
        var encryptOptions1 = new EncryptedTextOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = aesAlg.Key,
            Iv = aesAlg.IV
        };

        aesAlg.GenerateIV();
        var encryptOptions2 = new EncryptedTextOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = aesAlg.Key,
            Iv = aesAlg.IV
        };

        var decryptedText = encryptedText.ToString(_options);
        // Changing key
        var actDecrypt1 = () => encryptedText.ToString(encryptOptions1);
        // Changing IV
        var actDecrypt2 = () => encryptedText.ToString(encryptOptions2);

        actDecrypt1.Should().Throw<CryptographicException>();
        actDecrypt2.Should().Throw<CryptographicException>();
    }

    [Fact]
    public void EncryptedText_Equals_ReturnsFalse()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _options);
        var encryptedText2 = EncryptedText.FromPlainText(PlainText, _options);

        encryptedText.Should().NotBeNull();
        encryptedText2.Should().NotBeNull();
        encryptedText.Equals(encryptedText2).Should().BeFalse();
    }
}