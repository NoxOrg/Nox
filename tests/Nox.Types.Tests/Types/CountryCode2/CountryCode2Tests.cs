using Nox.Types.Tests.Types.CountryCode3;

namespace Nox.Types.Tests.Types;

public class CountryCode2Tests
{
    [Theory]
    [ClassData(typeof(CountryCode2TestsDataClass))]
    public void CountryCode2_Constructor_ReturnsSameValue_AllCountries(string countryCode2String)
    {
        var countryCode2 = CountryCode2.From(countryCode2String);

        Assert.Equal(countryCode2String, countryCode2.Value);
    }

    [Fact]
    public void CountryCode2_Constructor_WithUnsupportedCountryCode2_ThrowsValidationException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          CountryCode2.From("ABC")
        );

        Assert.Equal("Could not create a Nox CountryCode2 type with unsupported value 'ABC'.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void CountryCode2_Equality_Tests()
    {
        var countryCode2_1 = CountryCode2.From("AF");

        var countryCode2_2 = CountryCode2.From("AF");

        Assert.Equal(countryCode2_1, countryCode2_2);
    }

    [Fact]
    public void CountryCode2_NotEqual_Tests()
    {
        var countryCode2_1 = CountryCode2.From("AF");

        var countryCode2_2 = CountryCode2.From("AX");

        Assert.NotEqual(countryCode2_1, countryCode2_2);
    }

    [Fact]
    public void CountryCide2_ToString_ReturnsString()
    {
        var countryCode2 = CountryCode2.From("AF");

        Assert.Equal("AF", countryCode2.ToString());
    }
}
