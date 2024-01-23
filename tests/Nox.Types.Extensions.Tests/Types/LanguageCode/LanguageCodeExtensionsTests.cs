using FluentAssertions;

namespace Nox.Types.Extensions.Tests.Types.LanguageCode;

public class LanguageCodeExtensionsTests : WorldTestBase
{
    [Theory]
    [InlineData("tr")]
    [InlineData("en")]
    [InlineData("de")]
    [InlineData("fr")]
    public void WhenGettingReferenceLanguage_WithValidLanguageCode_ThenReturnsLanguage(string languageIsoCode)
    {
        // Arrange
        // Act
        var languageCode = Nox.Types.LanguageCode.From(languageIsoCode);
        var referenceLanguage = languageCode.GetReferenceLanguage();

        // Assert
        languageCode.Should().NotBeNull();
        referenceLanguage.Should().NotBeNull();
        referenceLanguage.Iso_639_1.Should().Be(languageIsoCode);
    }
}