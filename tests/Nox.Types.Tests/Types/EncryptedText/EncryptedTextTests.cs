// ReSharper disable once CheckNamespace

using System.Security.Cryptography;
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class EncryptedTextTests
{
    private readonly EncryptedTextTypeOptions _typeOptions;
    private const string PlainText = "plain text";
    private readonly Aes _aesAlg;

    public EncryptedTextTests()
    {
        _aesAlg = Aes.Create();

        _typeOptions = new EncryptedTextTypeOptions
        {
            PublicKey = Convert.ToBase64String(_aesAlg.Key),
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            Iv = Convert.ToBase64String(_aesAlg.IV)
        };
    }

    [Fact]
    public void Constructor_ReturnsEncryptedValue()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _typeOptions);

        encryptedText.Should().NotBeNull();
        encryptedText.Value.Should().NotBeNull().And.NotBeEmpty();
    }

    [Fact]
    public void Decryption_ReturnsOriginalValue()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _typeOptions);
        var decryptedText = encryptedText.DecryptText(_typeOptions);

        PlainText.Should().Be(decryptedText);
    }

    [Fact]
    public void SameEncryptParameters_Returns_SameEncryptedValue()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _typeOptions);
        var encryptedText2 = EncryptedText.FromPlainText(PlainText, _typeOptions);

        encryptedText.Should().NotBeNull();
        encryptedText2.Should().NotBeNull();
        encryptedText.Value.Should().Be(encryptedText2.Value);
    }

    [Fact]
    public void DifferentEncryptParameters_Returns_DifferentEncryptedValue()
    {
        // Change key
        _aesAlg.GenerateKey();
        var encryptOptions1 = new EncryptedTextTypeOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = Convert.ToBase64String(_aesAlg.Key),
            Iv = Convert.ToBase64String(_aesAlg.IV)
        };

        // Change IV
        _aesAlg.GenerateIV();
        var encryptOptions2 = new EncryptedTextTypeOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = Convert.ToBase64String(_aesAlg.Key),
            Iv = Convert.ToBase64String(_aesAlg.IV)
        };

        var encryptedText = EncryptedText.FromPlainText(PlainText, _typeOptions);
        // Different key
        var encryptedText1 = EncryptedText.FromPlainText(PlainText, encryptOptions1);
        // Different IV
        var encryptedText2 = EncryptedText.FromPlainText(PlainText, encryptOptions2);

        encryptedText.Value.Should().NotBe(encryptedText1.Value);
        encryptedText.Value.Should().NotBe(encryptedText2.Value);
        encryptedText1.Value.Should().NotBe(encryptedText2.Value);

    }

    [Fact]
    public void EncryptedText_Equals_SameEncryptedText_ReturnsTrue()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _typeOptions);
        var encryptedText2 = EncryptedText.FromPlainText(PlainText, _typeOptions);

        encryptedText.Equals(encryptedText2).Should().BeTrue();
    }

    [Fact]
    public void EncryptedText_Equals_DifferentEncryptedText_ReturnsFalse()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _typeOptions);
        var encryptedText2 = EncryptedText.FromPlainText("other text", _typeOptions);

        encryptedText.Equals(encryptedText2).Should().BeFalse();
    }

    [Fact]
    public void Decryption_With_DifferentOptions_ThrowsCryptographicException()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _typeOptions);

        _aesAlg.GenerateKey();
        var encryptOptionsChangingKey = new EncryptedTextTypeOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = Convert.ToBase64String(_aesAlg.Key),
            Iv = Convert.ToBase64String(_aesAlg.IV)
        };

        _aesAlg.GenerateIV();
        var encryptOptionsChangingIv = new EncryptedTextTypeOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = Convert.ToBase64String(_aesAlg.Key),
            Iv = Convert.ToBase64String(_aesAlg.IV)
        };

        var decryptedText = encryptedText.DecryptText(_typeOptions);
        // Changing key
        var actDecryptChangingKey = () => encryptedText.DecryptText(encryptOptionsChangingKey);
        // Changing IV
        var actDecryptChangingIv = () => encryptedText.DecryptText(encryptOptionsChangingIv);

        actDecryptChangingKey.Should().Throw<CryptographicException>();
        actDecryptChangingIv.Should().Throw<CryptographicException>();
    }

    [Fact]
    public void EncryptText_With_InvalidOptions_ThrowsArgumentException()
    {
        var encryptOptionsWithoutKey = new EncryptedTextTypeOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            Iv = Convert.ToBase64String(_aesAlg.IV)
        };

        var encryptOptionsWithoutIv = new EncryptedTextTypeOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = Convert.ToBase64String(_aesAlg.Key)
        };

        var actDecrypt1 = () => EncryptedText.FromPlainText(PlainText, encryptOptionsWithoutKey);
        var actDecrypt2 = () => EncryptedText.FromPlainText(PlainText, encryptOptionsWithoutIv);

        actDecrypt1.Should().Throw<ArgumentNullException>();
        actDecrypt2.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void DecryptText_With_InvalidOptions_ThrowsArgumentException()
    {
        var encryptedText = EncryptedText.FromPlainText(PlainText, _typeOptions);

        var encryptOptionsWithoutKey = new EncryptedTextTypeOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            Iv = Convert.ToBase64String(_aesAlg.IV)
        };

        var encryptOptionsWithoutIv = new EncryptedTextTypeOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes,
            PublicKey = Convert.ToBase64String(_aesAlg.Key)
        };

        var actDecrypt1 = () => encryptedText.DecryptText(encryptOptionsWithoutKey);
        var actDecrypt2 = () => encryptedText.DecryptText(encryptOptionsWithoutIv);

        actDecrypt1.Should().Throw<ArgumentNullException>();
        actDecrypt2.Should().Throw<ArgumentNullException>();
    }
}