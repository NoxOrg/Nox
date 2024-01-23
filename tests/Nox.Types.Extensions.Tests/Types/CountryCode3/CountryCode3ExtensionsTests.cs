using FluentAssertions;

namespace Nox.Types.Extensions.Tests.Types;

public class CountryCode3ExtensionsTests : WorldTestBase
{
    [Theory]
    [InlineData("462", "MV", "MDV", "Maldives")]
    [InlineData("604", "PE", "PER", "Peru")]
    [InlineData("732", "EH", "ESH", "Western Sahara")]
    public void WhenGettingReferenceCountry_WithValidCountryCode3_ThenReturnsCountry(string countryNumber, string countryCode2, string countryCode3, string countryName)
    {
        // Arrange
        // Act
        var country = CountryCode3.From(countryCode3).GetReferenceCountry();

        // Assert
        country.Should().NotBeNull();
        country.NumericCode.Should().Be(countryNumber);
        country.AlphaCode2.Should().Be(countryCode2);
        country.AlphaCode3.Should().Be(countryCode3);
        country.Names.CommonName.Should().Be(countryName);
    }
}