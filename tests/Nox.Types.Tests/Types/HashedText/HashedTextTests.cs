// ReSharper disable once CheckNamespace
using System.Security.Cryptography;
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class HashedTextTests
{

    [Fact]
    public void HashedText_Constructor_WithoutOptions_ReturnsHashedValue()
    {
        string text = "Text to hash";
        var hashedText = HashedText.From(text);

        hashedText.Should().NotBeNull();
        hashedText.Value.Salt.Should().NotBeNull().And.NotBe(text);
    }


    [Fact]
    public void HashedText_Constructor_WithOptions_ReturnsHashedValue()
    {
        string text = "Text to hash";
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = SHA512.HashData(textData);
        var textHashedExpected = Convert.ToBase64String(hash);

        var hashedText = HashedText.From(text, new HashedTextTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, Salt = 0 });

        hashedText.Value.HashText.Should().Be(textHashedExpected);
    }

    [Fact]
    public void HashedText_Equals_ReturnsTrue()
    {
        string text = "Text to hash";
        byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = SHA512.HashData(textBytes);
        var textHashedExpected = Convert.ToBase64String(hash);

        var hashedText = HashedText.From(text, new HashedTextTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, Salt = 0 });
        var expectedHashedText = HashedText.From((textHashedExpected, ""));

        hashedText.Equals(expectedHashedText).Should().BeTrue();
    }

    [Fact]
    public void HashedText_Equals_ReturnsFalse_Salting()
    {
        string text = "Text to hash";
        var hashedText = HashedText.From(text, new HashedTextTypeOptions() { HashingAlgorithm = HashingAlgorithm.SHA512, Salt = 0 });
        var hashedTextNoSalting = HashedText.From(text);

        hashedText.Equals(hashedTextNoSalting).Should().BeFalse();
    }

    [Fact]
    public void HashedText_Equals_ReturnsFalse()
    {
        string text = "Text to hash";
        string text1 = $"{text} 1";
        var hashedText1 = HashedText.From(text1);
        var hashedText = HashedText.From(text);

        hashedText.Equals(hashedText1).Should().BeFalse();
    }

    [Fact]
    public void HashedText_FromHashedValue_Delimiter_NoSalt()
    {
        string text = "Text to hash";
        string salt = "Salt";
        var hashedText = HashedText.From((text, salt));

        hashedText.Value.HashText.Should().Be(text);
        hashedText.Value.Salt.Should().Be(salt);
    }
}