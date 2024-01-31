// ReSharper disable once CheckNamespace

using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class StreetAddressTests
{
    [Theory]
    [InlineData("5", "Line1", "", "","Locality", "11111", "UA", "", "Line1, Locality, 11111, UA")]
    [InlineData("5", "Line1", "Line2", "Line3","Locality", "11111", "UA", "", "Line1 Line2 Line3, Locality, 11111, UA")]
    [InlineData("5", "Line1", "", "","", "11111", "UA", "", "Line1, 11111, UA")]
    [InlineData("5", "Line1", "Line2", "Line3","Locality", "11111", "UA", "KH", "Line1 Line2 Line3, Locality, KH 11111, UA")]
    public void StreetAddress_ToString_ReturnsValidAddress(
        string streetNumber,
        string addressLine1,
        string addressLine2,
        string addressLine3,
        string locality,
        string postalCode,
        string countryCode,
        string administrativeArea1,
        string expectedAddress)
    {
        var address = StreetAddress.From(new StreetAddressItem
        {
            StreetNumber = streetNumber,
            AddressLine1 = addressLine1,
            AddressLine2 = addressLine2,
            AddressLine3 = addressLine3,
            Route = "Route",
            Locality = locality,
            AdministrativeArea1 = administrativeArea1,
            PostalCode = postalCode,
            CountryId = System.Enum.Parse<CountryCode>(countryCode)
        });

        address.ToString().Should().Be(expectedAddress);
    }

    [Theory]
    [InlineData("CH")]
    [InlineData("UA")]
    [InlineData("US")]
    [InlineData("GB")]
    public void StreetAddress_WrongPostalCode_ThrowsException(string countryCode)
    {
        var action = () => StreetAddress.From(new StreetAddressItem
        {
            PostalCode = "123456",
            CountryId = System.Enum.Parse<CountryCode>(countryCode),
            AddressLine1 = "Line 1"
        });

        action.Should().Throw<NoxTypeValidationException>()
            .WithMessage($"The Nox type validation failed with 1 error(s). PropertyName: PostalCode. Error: PostalCode '123456' for country with ID '{countryCode}' is invalid.")
            .And.Errors.Should().BeEquivalentTo(new[]
            {
                new ValidationFailure("PostalCode", $"PostalCode '123456' for country with ID '{countryCode}' is invalid.")
            });
    }

    [Theory]
    [InlineData("CH", "1234")]
    [InlineData("UA", "12345")]
    [InlineData("US", "99577-0727")]
    [InlineData("GB", "AB12CD")]
    public void StreetAddress_ValidPostalCode_CanBeCreated(string countryCode, string postalCode)
    {
        var address = StreetAddress.From(new StreetAddressItem
        {
            PostalCode = postalCode,
            CountryId = System.Enum.Parse<CountryCode>(countryCode),
            AddressLine1 = "Line 1"
        });

        address.PostalCode.Should().Be(postalCode);
    }

    [Fact]
    public void StreetAddress_WithPropertyAboveMaxLength_ThrowsException()
    {
        var action = () => StreetAddress.From(new StreetAddressItem
        {
            StreetNumber = new string('a', 33),
            AddressLine1 = new string('a', 129),
            AddressLine2 = new string('a', 129),
            AddressLine3 = new string('a', 129),
            Route = new string('a', 65),
            Locality = new string('a', 65),
            AdministrativeArea1 = new string('a', 65),
            AdministrativeArea2 = new string('a', 65),
            PostalCode = "1234",
            CountryId = CountryCode.CH
        });

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[]
            {
                new ValidationFailure("StreetNumber", "Could not create a Nox StreetAddress type with a StreetNumber with length greater than max allowed length of 32."),
                new ValidationFailure("AddressLine1", "Could not create a Nox StreetAddress type with a AddressLine1 with length greater than max allowed length of 128."),
                new ValidationFailure("AddressLine2", "Could not create a Nox StreetAddress type with a AddressLine2 with length greater than max allowed length of 128."),
                new ValidationFailure("AddressLine3", "Could not create a Nox StreetAddress type with a AddressLine3 with length greater than max allowed length of 128."),
                new ValidationFailure("Route", "Could not create a Nox StreetAddress type with a Route with length greater than max allowed length of 64."),
                new ValidationFailure("Locality", "Could not create a Nox StreetAddress type with a Locality with length greater than max allowed length of 64."),
                new ValidationFailure("AdministrativeArea1", "Could not create a Nox StreetAddress type with a AdministrativeArea1 with length greater than max allowed length of 64."),
                new ValidationFailure("AdministrativeArea2", "Could not create a Nox StreetAddress type with a AdministrativeArea2 with length greater than max allowed length of 64."),
            });
    }

    [Fact]
    public void StreetAddress_WhenStreetAddresLine1IsNotSpecified_ThrowsException()
    {
        var action = () => StreetAddress.From(new StreetAddressItem
        {
            StreetNumber = "3000",
            Route = "Hillswood Drive",
            Locality = "Lyne",
            AdministrativeArea1 = "England",
            AdministrativeArea2 = "Surrey",
            PostalCode = "GIR0AA",
            CountryId = CountryCode.GB
        });

        action.Should().Throw<NoxTypeValidationException>()
            .WithMessage("The Nox type validation failed with 1 error(s). PropertyName: AddressLine1. Error: Could not create a Nox StreetAddress type with an empty AddressLine1.")
            .And.Errors.Should().BeEquivalentTo(new[]
            {
                new ValidationFailure("AddressLine1", "Could not create a Nox StreetAddress type with an empty AddressLine1.")
            });
    }

    [Fact]
    public void StreetAddress_WhenPostalCodeIsNotSpecified_ShouldBeValid()
    {
        var action = () => StreetAddress.From(new StreetAddressItem
        {
            StreetNumber = "3000",
            AddressLine1 = "Hillswood Business Park",
            Route = "Hillswood Drive",
            Locality = "Lyne",
            AdministrativeArea1 = "England",
            AdministrativeArea2 = "Surrey",
            CountryId = CountryCode.GB
        });

        action.Should().NotThrow();
    }

    [Fact]
    public void StreetAddress_WhenCountryIdIsNotSpecified_ThrowsException()
    {
        var action = () => StreetAddress.From(new StreetAddressItem
        {
            StreetNumber = "3000",
            AddressLine1 = "Hillswood Business Park",
            Route = "Hillswood Drive",
            Locality = "Lyne",
            AdministrativeArea1 = "England",
            AdministrativeArea2 = "Surrey",
            PostalCode = "GIR0AA",
        });

        action.Should().Throw<NoxTypeValidationException>()
            .WithMessage("The Nox type validation failed with 1 error(s). PropertyName: CountryId. Error: Country with ID '0' is invalid.")
            .And.Errors.Should().BeEquivalentTo(new[]
            {
                new ValidationFailure("CountryId", "Country with ID '0' is invalid.")
            });
    }
}