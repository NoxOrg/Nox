using FluentAssertions;
using Nox.Reference;
using Nox.Reference.Data.World;

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
        using var worldContext = new WorldContext();
        var country = worldContext.GetCountriesQuery().GetByAlpha2Code(countryCode)!;

        // Act
        var countryCode2 = country.GetCountryCode2();

        // Assert
        countryCode2.Should().Be(CountryCode2.From(countryCode));
    }
}