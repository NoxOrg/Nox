using FluentAssertions;

namespace Nox.Types.Extensions.Tests.Types.CultureCode;

public class CultureCodeExtensionsTests: WorldTestBase
{
    [Theory]
    [InlineData("tr-TR")]
    [InlineData("en")]
    [InlineData("agq-CM")]
    [InlineData("bs-Latn-BA")]
    public void WhenGettingReferenceCulture_WithValidCultureCode_ThenReturnsCulture(string cultureCode)
    {
        // Arrange Act
        var culture = Nox.Types.CultureCode.From(cultureCode).GetReferenceCulture();
        // Assert
        culture.Should().NotBeNull();
        culture.Name.Should().Be(cultureCode);
    }
}