// ReSharper disable once CheckNamespace

using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class StreetAddressTests
{
    [Theory]
    [InlineData("5", "Line1", "", "Locality", "11111", "UA", "", "Line1, Locality, 11111, UA")]
    [InlineData("5", "Line1", "Line2", "Locality", "11111", "UA", "", "Line1 Line2, Locality, 11111, UA")]
    [InlineData("5", "Line1", "", "", "11111", "UA", "", "Line1, 11111, UA")]
    [InlineData("5", "Line1", "Line2", "Locality", "11111", "UA", "KH", "Line1 Line2, Locality, KH 11111, UA")]
    public void StreetAddress_ToString_ReturnsValidAddress(
        string streetNumber,
        string addressLine1,
        string addressLine2,
        string locality,
        string postalCode,
        string countryCode,
        string administrativeArea1,
        string expectedAddress)
    {
        var countryCode2 = System.Enum.Parse<CountryCode>(countryCode);
        var address = StreetAddress.From(new StreetAddressItem
        {
            StreetNumber = streetNumber,
            AddressLine1 = addressLine1,
            AddressLine2 = addressLine2,
            Route = "Route",
            Locality = locality,
            AdministrativeArea1 = administrativeArea1,
            PostalCode = postalCode,
            CountryId = countryCode2
        });

        Assert.Equal(expectedAddress, address.ToString());
    }

    [Theory]
    [InlineData("CH")]
    [InlineData("UA")]
    [InlineData("US")]
    [InlineData("GB")]
    public void StreetAddress_WrongPostalCode_ThrowsException(string countryCode)
    {
        var exception = Assert.Throws<TypeValidationException>(() => StreetAddress.From(new StreetAddressItem
        {
            PostalCode = "123456",
            CountryId = System.Enum.Parse<CountryCode>(countryCode),
            AddressLine1 = "Line 1"
        }));

        exception.Errors.First().Variable.Should().Be("PostalCode");
    }

    [Theory]
    [InlineData("CH", "1234")]
    [InlineData("UA", "12345")]
    [InlineData("US", "99577-0727")]
    [InlineData("GB", "BT41 1AA")]
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
        var exception = Assert.Throws<TypeValidationException>(() => StreetAddress.From(new StreetAddressItem
        {
            StreetNumber = new string('a', 33),
            AddressLine1 = new string('a', 129),
            AddressLine2 = new string('a', 129),
            Route = new string('a', 65),
            Locality = new string('a', 65),
            AdministrativeArea1 = new string('a', 65),
            PostalCode = "1234",
            CountryId = CountryCode.CH
        }));

        exception.Errors.All(x => x.ErrorMessage.Contains(
            $"Could not create a Nox StreetAddress type with a {x.Variable} with length greater than max allowed length of "
        )).Should().BeTrue();
    }
}