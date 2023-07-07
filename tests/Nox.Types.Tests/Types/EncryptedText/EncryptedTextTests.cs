// ReSharper disable once CheckNamespace

using System.Security.Cryptography;
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class EncryptedTextTests
{
    private readonly EncryptedTextOptions _options;
    private const string PlainText = "plain text";
    private readonly Aes _aesAlg;

    public EncryptedTextTests()
    {
        _aesAlg = Aes.Create();

        _options = new EncryptedTextOptions
        {
            PublicKey = _aesAlg.Key,
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            Iv = _aesAlg.IV
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
        // Change key
        _aesAlg.GenerateKey();
        var encryptOptions1 = new EncryptedTextOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = _aesAlg.Key,
            Iv = _aesAlg.IV
        };

        // Change IV
        _aesAlg.GenerateIV();
        var encryptOptions2 = new EncryptedTextOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = _aesAlg.Key,
            Iv = _aesAlg.IV
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
    public void EncryptedText_Equals_ReturnsFalse()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _options);
        var encryptedText2 = EncryptedText.FromPlainText(PlainText, _options);

        encryptedText.Should().NotBeNull();
        encryptedText2.Should().NotBeNull();
        encryptedText.Equals(encryptedText2).Should().BeFalse();
    }

    [Fact]
    public void Decryption_With_DifferentOptions_ThrowsCryptographicException()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _options);

        _aesAlg.GenerateKey();
        var encryptOptionsChangingKey = new EncryptedTextOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = _aesAlg.Key,
            Iv = _aesAlg.IV
        };

        _aesAlg.GenerateIV();
        var encryptOptionsChangingIv = new EncryptedTextOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = _aesAlg.Key,
            Iv = _aesAlg.IV
        };

        var decryptedText = encryptedText.ToString(_options);
        // Changing key
        var actDecryptChangingKey = () => encryptedText.ToString(encryptOptionsChangingKey);
        // Changing IV
        var actDecryptChangingIv = () => encryptedText.ToString(encryptOptionsChangingIv);

        actDecryptChangingKey.Should().Throw<CryptographicException>();
        actDecryptChangingIv.Should().Throw<CryptographicException>();
    }

    [Fact]
    public void EncryptText_With_InvalidOptions_ThrowsArgumentException()
    {
        var encryptOptionsWithoutKey = new EncryptedTextOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            Iv = _aesAlg.IV
        };

        var encryptOptionsWithoutIv = new EncryptedTextOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = _aesAlg.Key
        };

        var actDecrypt1 = () => EncryptedText.FromPlainText(PlainText, encryptOptionsWithoutKey);
        var actDecrypt2 = () => EncryptedText.FromPlainText(PlainText, encryptOptionsWithoutIv);

        actDecrypt1.Should().Throw<ArgumentNullException>();
        actDecrypt2.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void DecryptText_With_InvalidOptions_ThrowsArgumentException()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _options);

        var encryptOptionsWithoutKey = new EncryptedTextOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            Iv = _aesAlg.IV
        };

        var encryptOptionsWithoutIv = new EncryptedTextOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = _aesAlg.Key
        };

        var actDecrypt1 = () => encryptedText.ToString(encryptOptionsWithoutKey);
        var actDecrypt2 = () => encryptedText.ToString(encryptOptionsWithoutIv);

        actDecrypt1.Should().Throw<ArgumentNullException>();
        actDecrypt2.Should().Throw<ArgumentNullException>();
    }
}