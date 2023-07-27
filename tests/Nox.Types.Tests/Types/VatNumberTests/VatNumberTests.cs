using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class VatNumberTests
{    
    [Fact]
    public void VatNumber_ParameterizedConstructor_Success()
    {
        var vatNumberValue = "44403198682";
        var countryCode = CountryCode2.From("FR");

        var vatNumber = VatNumber.From(vatNumberValue, countryCode);

        vatNumber.Value.Should().Be((vatNumberValue, countryCode));
    }

    [Fact]
    public void VatNumber_ParameterizedConstructor_WithUnsupportedCountryCode()
    {
        var vatNumberValue = "44403198682";
        var countryCode = CountryCode2.From("UA");

        var action = () => VatNumber.From(vatNumberValue, countryCode);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox VatNumber type with unsupported CountryCode 'UA'.") });
    }

    [Fact]
    public void VatNumber_ParameterizedConstructor_WithUnsupportedFormat()
    {
        var vatNumberValue = "44403198682123";
        var countryCode = CountryCode2.From("FR");

        var action = () => VatNumber.From(vatNumberValue, countryCode);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox VatNumber type with unsupported value 'FR44403198682123'.") });
    }

    [Fact]
    public void VatNumber_Should_Equal()
    {
        var vatNumber1 = VatNumber.From("44403198682", CountryCode2.From("FR"));
        var vatNumber2 = VatNumber.From("44403198682", CountryCode2.From("FR"));

        vatNumber1.Should().Be(vatNumber2);
    }

    [Fact]
    public void VatNumber_Should_Not_Equal()
    {
        var vatNumber1 = VatNumber.From("44403198682", CountryCode2.From("FR")); 
        var vatNumber2 = VatNumber.From("157050817", CountryCode2.From("DE"));

        vatNumber1.Should().NotBe(vatNumber2);
    }

    [Fact]
    public void VatNumber_From_With_Default_Options()
    {
        var vatNumberValue = "123456789";

        var vatNumber = VatNumber.From(vatNumberValue, new VatNumberOptions());

        vatNumber.Value.Should().Be((vatNumberValue, CountryCode2.From("GB")));
    }

    [Fact]
    public void VatNumber_From_With_Custom_Options()
    {
        var vatNumberValue = "157050817";

        var vatNumber = VatNumber.From(
            vatNumberValue,
            new VatNumberOptions { CountryCode = "DE" }
            );

        vatNumber.Value.Should().Be((vatNumberValue, CountryCode2.From("DE")));
    }

    [Fact]
    public void VatNumber_From_String_CountryCode()
    {
        var vatNumberValue = "44403198682";
        var countryCode = "FR";

        var vatNumber = VatNumber.From(
            vatNumberValue,
            countryCode
            );

        vatNumber.Value.Should().Be((vatNumberValue, CountryCode2.From(countryCode)));
    }

    [Fact]
    public void VatNumber_ToString_Success()
    {
        var vatNumber = VatNumber.From("44403198682", CountryCode2.From("FR"));

        vatNumber.ToString().Should().Be("FR44403198682");
    }

    [Theory]
    [InlineData("AT", "U12345678")]
    [InlineData("BG", "123456789")]
    [InlineData("BG", "1234567890")]
    [InlineData("DK", "12345678")]
    [InlineData("EE", "123456789")]
    [InlineData("FI", "12345678")]
    [InlineData("FR", "12345678901")]
    [InlineData("FR", "XX123456789")]
    [InlineData("DE", "123456789")]
    [InlineData("HU", "12345678")]
    [InlineData("IT", "12345678901")]
    public void VatNumber_Supported_Formats(string countryCode, string vatNumberValue)
    {
        var countryCode2 = CountryCode2.From(countryCode);

        var vatNumber = VatNumber.From(vatNumberValue, countryCode2);

        vatNumber.Value.Should().Be((vatNumberValue, countryCode2));
    }
}