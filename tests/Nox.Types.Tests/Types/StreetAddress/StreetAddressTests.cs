// ReSharper disable once CheckNamespace
namespace Nox.Types.Tests.Types;

public class StreetAddressTests
{
    [Theory]
    [InlineData(5, "Line1", "", "Locality", "11111", "UA", "", "Line1, Locality, 11111, UA")]
    [InlineData(5, "", "Line2", "Locality", "11111", "UA", "", "Line2, Locality, 11111, UA")]
    [InlineData(5, "", "", "Locality", "11111", "UA", "", "Locality, 11111, UA")]
    [InlineData(5, "Line1", "Line2", "Locality", "11111", "UA", "KH", "Line1 Line2, Locality, KH 11111, UA")]
    public void StreetAddress_ToString_ReturnsValidAddress(
        int streetNumber,
        string addressLine1,
        string addressLine2,
        string locality,
        string postalCode,
        string countryCode,
        string administrativeArea1,
        string expectedAddress)
    {
        var countryCode2 = CountryCode2.From(countryCode);
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
    public void StreetAddress_WrongPostalCode_Throws(string countryCode)
    {
        var exception = Assert.Throws<TypeValidationException>(() => StreetAddress.From(new StreetAddressItem
        {
            PostalCode = "123456",
            CountryId = CountryCode2.From(countryCode)
        }));

        Assert.Contains(exception.Errors, t => t.Variable == "PostalCode");
    }

    [Theory]
    [InlineData("CH", "1234")]
    [InlineData("UA", "12345")]
    [InlineData("US", "99577-0727")]
    [InlineData("GB", "BT41 1AA")]
    public void StreetAddress_ValidPostalCode_NotThrow(string countryCode, string postalCode)
    {
        var address = StreetAddress.From(new StreetAddressItem
        {
            PostalCode = postalCode,
            CountryId = CountryCode2.From(countryCode)
        });

        Assert.Equal(postalCode, address.PostalCode);
    }
}