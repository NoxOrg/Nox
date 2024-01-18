using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class VatNumberTests
{    
    [Fact]
    public void VatNumber_ParameterizedConstructor_Success()
    {
        var vatNumberValue = "FR44403198682";
        var countryCode = CountryCode.FR;

        var vatNumber = VatNumber.From(vatNumberValue, countryCode);

        vatNumber.Value.Should().Be((vatNumberValue, countryCode));
    }

    [Fact]
    public void VatNumber_ParameterizedConstructor_WithUnsupportedCountryCode()
    {
        var vatNumberValue = "44403198682";
        var countryCode = CountryCode.BA;

        var action = () => VatNumber.From(vatNumberValue, countryCode);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox VatNumber type with unsupported CountryCode 'BA'.") });
    }

    [Fact]
    public void VatNumber_ParameterizedConstructor_WithUnsupportedFormat()
    {
        var vatNumberValue = "FR44403198682123";
        var countryCode = "FR";

        var action = () => VatNumber.From(vatNumberValue, countryCode);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox VatNumber type with unsupported value 'FR44403198682123' for CountryCode 'FR'.") });
    }

    [Fact]
    public void VatNumber_Should_Equal()
    {
        var vatNumber1 = VatNumber.From("FR44403198682", "FR");
        var vatNumber2 = VatNumber.From("FR44403198682", CountryCode.FR);

        vatNumber1.Should().Be(vatNumber2);
    }

    [Fact]
    public void VatNumber_Should_Not_Equal()
    {
        var vatNumber1 = VatNumber.From("FR44403198682", CountryCode.FR); 
        var vatNumber2 = VatNumber.From("DE157050817", CountryCode.DE);

        vatNumber1.Should().NotBe(vatNumber2);
    }

    [Fact]
    public void VatNumber_From_With_Default_Options()
    {
        var vatNumberValue = "GB123456789";

        var vatNumber = VatNumber.From(vatNumberValue, new VatNumberTypeOptions());

        vatNumber.Value.Should().Be((vatNumberValue, CountryCode.GB));
    }

    [Fact]
    public void VatNumber_From_With_Custom_Options()
    {
        var vatNumberValue = "DE157050817";

        var vatNumber = VatNumber.From(
            vatNumberValue,
            new VatNumberTypeOptions { CountryCode = CountryCode.DE }
            );

        vatNumber.Value.Should().Be((vatNumberValue, CountryCode.DE));
    }

    [Fact]
    public void VatNumber_From_String_CountryCode()
    {
        var vatNumberValue = "FR44403198682";
        var countryCode = "FR";

        var vatNumber = VatNumber.From(
            vatNumberValue,
            countryCode
            );

        vatNumber.Value.Should().Be((vatNumberValue, System.Enum.Parse<CountryCode>(countryCode)));
    }

    [Fact]
    public void VatNumber_ToString_Success()
    {
        var vatNumber = VatNumber.From("FR44403198682", System.Enum.Parse<CountryCode>("FR"));

        vatNumber.ToString().Should().Be("FR44403198682");
    }

    [Theory]
    [InlineData("AT", "ATU12345678")]
    [InlineData("BG", "BG123456789")]
    [InlineData("BG", "BG1234567890")]
    [InlineData("DK", "DK12345678")]
    [InlineData("EE", "EE123456789")]
    [InlineData("FI", "FI12345678")]
    [InlineData("FR", "FR12345678901")]
    [InlineData("DE", "DE123456789")]
    [InlineData("HU", "HU12345678")]
    [InlineData("IT", "IT12345678901")]
    [InlineData("ES", "ES51234567A")]
    [InlineData("ES", "ESA12345678")]
    public void VatNumber_Supported_Formats(string countryCode, string vatNumberValue)
    {
        var countryCode2 = System.Enum.Parse<CountryCode>(countryCode);

        var vatNumber = VatNumber.From(vatNumberValue, countryCode2);

        vatNumber.Value.Should().Be((vatNumberValue, countryCode2));
    }
}