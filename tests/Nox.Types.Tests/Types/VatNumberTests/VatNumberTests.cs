// ReSharper disable once CheckNamespace
namespace Nox.Types.Tests.Types;

public class VatNumberTests
{
    [Fact]
    public void VatNumber_ParameterizedConstructor_Success()
    {
        //Arrange
        var vatNumberValue = "44403198682";
        var countryCode = CountryCode2.From("FR");

        //Act
        var vatNumber = VatNumber.From(vatNumberValue, countryCode);

        //Assert
        Assert.Equal(vatNumberValue, vatNumber.VatNumberValue);
        Assert.Equal(countryCode, vatNumber.CountryCode);
        Assert.Equal("FR", vatNumber.CountryCode.ToString());
    }

    [Fact]
    public void VatNumber_Should_Equal()
    {
        //Arrange
        var vatNumber1 = VatNumber.From("44403198682", CountryCode2.From("FR"));
        var vatNumber2 = VatNumber.From("44403198682", CountryCode2.From("FR"));

        //Act
        var result = vatNumber1.Equals(vatNumber2);

        //Assert
        Assert.True(result);
        Assert.Equal(vatNumber1, vatNumber2);
    }

    [Fact]
    public void VatNumber_Should_Not_Equal()
    {
        //Arrange
        var vatNumber1 = VatNumber.From("44403198682", CountryCode2.From("FR"));
        var vatNumber2 = VatNumber.From("157050817", CountryCode2.From("DE"));

        //Act
        var result = vatNumber1.Equals(vatNumber2);

        //Assert
        Assert.False(result);
        Assert.NotEqual(vatNumber1, vatNumber2);
    }

    [Fact]
    public void VatNumber_From_With_Default_Options()
    {
        //Arrange
        var vatNumberValue = "123456789";

        //Act
        var vatNumber = VatNumber.From(vatNumberValue, new VatNumberOptions());

        //Assert
        Assert.Equal(vatNumberValue, vatNumber.VatNumberValue);
        Assert.Equal("GB", vatNumber.CountryCode.ToString());
    }

    [Fact]
    public void VatNumber_From_With_Custom_Options()
    {
        //Arrange
        var vatNumberValue = "123456789";

        //Act
        var vatNumber = VatNumber.From(
            vatNumberValue,
            new VatNumberOptions { DefaultCountryCode = "UA" }
            );

        //Assert
        Assert.Equal(vatNumberValue, vatNumber.VatNumberValue);
        Assert.Equal("UA", vatNumber.CountryCode.ToString());
    }

    [Fact]
    public void VatNumber_From_With_Custom_Options_And_Country_Code()
    {
        //Arrange
        var vatNumberValue = "123456789";
        var countryCode = CountryCode2.From("FR");

        //Act
        var vatNumber = VatNumber.From(
            vatNumberValue,
            countryCode,
            new VatNumberOptions { DefaultCountryCode = "UA" }
            );

        //Assert
        Assert.Equal(vatNumberValue, vatNumber.VatNumberValue);
        Assert.Equal(countryCode, vatNumber.CountryCode);
        Assert.Equal("FR", vatNumber.CountryCode.ToString());
    }

    [Fact]
    public void VatNumber_ToString_Success()
    {
        var vatNumber = VatNumber.From("123456789", CountryCode2.From("FR"));

        Assert.Equal("FR123456789", vatNumber.ToString());
    }
}