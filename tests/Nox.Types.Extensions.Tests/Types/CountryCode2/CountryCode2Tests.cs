using FluentAssertions;

namespace Nox.Types.Extensions.Tests.Types;

public class CountryCode2Tests
{
    [Fact]
    public void WhenGettingReferenceCountry_WithValidCountryCode2_ThenReturnsCountry()
    {
        // Arrange
        var countryCode2 = CountryCode2.From("MV");

        // Act
        var country = countryCode2.GetReferenceCountry();

        // Assert
        country.Should().NotBeNull();
    }
}