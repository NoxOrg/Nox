using Nox.Types.Tests.Types.CountryCode3;

namespace Nox.Types.Tests.Types;

public class CountryNumberTests
{
    [Theory]
    [ClassData(typeof(CountryNumberTestsDataClass))]
    public void CountryNumber_Constructor_ReturnsSameValue(short value)
    {
        var countryNumber = CountryNumber.From(value);

        Assert.Equal(value, countryNumber.Value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(22)]
    [InlineData(900)]
    [InlineData(1000)]
    public void CountryNumber_Constructor_WithUnallowedValue_ThrowsException(short value)
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            CountryNumber.From(value)
        );

        Assert.Equal($"Could not create a Nox CountryNumber type as value {value} is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void CountryNumber_Equality_Tests()
    {
        var countryNumber1 = CountryNumber.From(214);

        var countryNumber2 = CountryNumber.From(214);

        Assert.Equal(countryNumber1, countryNumber2);
    }

    [Fact]
    public void CountryNumber_NotEqual_Tests()
    {
        var countryNumber1 = CountryNumber.From(218);

        var countryNumber2 = CountryNumber.From(222);

        Assert.NotEqual(countryNumber1, countryNumber2);
    }

    [Theory]
    [InlineData(4, "004")]
    [InlineData(12, "012")]
    [InlineData(124, "124")]
    public void CountryNumber_ToString_ReturnsThreeDigitStringRepresentation(short value, string threeDigitStringRepresentation)
    {
        void Test()
        {
            var countryNumber = CountryNumber.From(value);

            Assert.Equal(threeDigitStringRepresentation, countryNumber.ToString());
        }

        TestUtility.RunInInvariantCulture(Test);
    }
}
