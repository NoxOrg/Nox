using FluentAssertions;
using Nox.Reference;

namespace Nox.Types.Extensions.Tests.Types;

public partial class CountryExtensionsTests : WorldTestBase
{
    [Theory]
    [InlineData("MV")]
    [InlineData("PE")]
    [InlineData("EH")]
    public void WhenGettingCountryCode2_WithValidCountry_ThenReturnsCountryCode2(string countryCode)
    {
        // Arrange
        var country = World.Countries.GetByAlpha2Code(countryCode)!;

        // Act
        var countryCode2 = country.GetCountryCode2();

        // Assert
        countryCode2.Should().Be(CountryCode2.From(countryCode));
    }
}