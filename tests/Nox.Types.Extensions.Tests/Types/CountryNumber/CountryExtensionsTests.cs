using FluentAssertions;
using Nox.Reference;
using Nox.Reference.Data.World;

namespace Nox.Types.Extensions.Tests.Types;

public partial class CountryExtensionsTests : WorldTestBase
{
    [Theory]
    [InlineData("462")]
    [InlineData("604")]
    [InlineData("732")]
    public void WhenGettingCountryNumber_WithValidCountry_ThenReturnsCountryNumber(string countryCode)
    {
        // Arrange
        using var worldContext = new WorldContext();
        var country = worldContext.GetCountriesQuery().GetByNumericCode(countryCode)!;

        // Act
        var countryNumber = country.GetCountryNumber();

        // Assert
        countryNumber.Should().Be(CountryNumber.From(ushort.Parse(countryCode)));
    }
}