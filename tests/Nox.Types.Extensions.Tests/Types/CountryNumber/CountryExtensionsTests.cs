using FluentAssertions;
using Nox.Reference;

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
        var country = World.Countries.GetByNumericCode(countryCode)!;

        // Act
        var countryNumber = country.GetCountryNumber();

        // Assert
        countryNumber.Should().Be(CountryNumber.From(ushort.Parse(countryCode)));
    }
}