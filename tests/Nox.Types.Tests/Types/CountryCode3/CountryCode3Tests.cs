using Nox.Types.Tests.Types.CountryCode3;

namespace Nox.Types.Tests;

public class CountryCode3Tests
{
    [Theory]
    [ClassData(typeof(CountryCode3TestsDataClass))]
    public void CreatingCountryCode3_From_IsValid(string countryCode3String)
    {
        var countryCode3 = CountryCode3.From(countryCode3String);

        Assert.Equal(countryCode3String, countryCode3.Value);
    }

    [Fact]
    public void CreatingCountryCode3_UnsupportedCountryCode3_ThrowsValidationException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          CountryCode3.From("ABC")
        );

        Assert.Equal("Could not create a Nox CountryCode3 type with unsupported value 'ABC'.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void CreatingCountryCode3_SameCountryCode3_ReturnsEqual()
    {
        var countryCode3_1 = CountryCode3.From("AFG");

        var countryCode3_2 = CountryCode3.From("AFG");

        Assert.Equal(countryCode3_1, countryCode3_2);
    }

    [Fact]
    public void CreatingCountryCode3_DifferentCountryCode3_ReturnsUnEqual()
    {
        var countryCode3_1 = CountryCode3.From("AFG");

        var countryCode3_2 = CountryCode3.From("ALA");

        Assert.NotEqual(countryCode3_1, countryCode3_2);
    }

    [Fact]
    public void CountryCode3_ToString_ReturnsValueAsString()
    {
        var countryCode3 = CountryCode3.From("AFG");

        Assert.Equal("AFG", countryCode3.ToString());
    }
}
