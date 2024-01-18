using FluentAssertions;
using Nox.Reference;

namespace Nox.Types.Extensions.Tests.Types;

public partial class CountryExtensionsTests : WorldTestBase
{
    [Theory]
    [InlineData("MDV")]
    [InlineData("PER")]
    [InlineData("ESH")]
    public void WhenGettingCountryCode3_WithValidCountry_ThenReturnsCountryCode3(string countryCode)
    {
        // Arrange
        var country = World.Countries.GetByAlpha3Code(countryCode)!;

        // Act
        var countryCode3 = country.GetCountryCode3();

        // Assert
        countryCode3.Should().Be(CountryCode3.From(countryCode));
    }
}