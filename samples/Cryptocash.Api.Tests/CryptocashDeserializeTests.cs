using Nox.Solution;
using Nox.Docs.Extensions;
using FluentAssertions;
using System.Text.Json;
using Cryptocash.Application.Dto;
using System.Text.Json.Serialization;

namespace Cryptocash.Tests;

public class CryptocashDeserializeTests
{
    [Fact]
    public void Deserialize_VendingMachineDto()
    {
        var rawJson = "{\r\n  \"@odata.context\": \"https://localhost:44310/api/$metadata#VendingMachines/$entity\",\r\n  \"@odata.etag\": \"4aa1c5cd-1040-4b5c-82e4-e41129754836\",\r\n  \"Id\": \"fe0c369b-e737-4881-8e7f-7e8874bc067b\",\r\n  \"MacAddress\": \"DD11223344AA\",\r\n  \"PublicIp\": \"80.123.80.123\",\r\n  \"SerialNumber\": \"SN654321\",\r\n  \"InstallationFootPrint\": 10.5,\r\n  \"VendingMachineInstallationCountryId\": \"CH\",\r\n  \"VendingMachineContractedAreaLandLordId\": 3,\r\n  \"GeoLocation\": {\r\n    \"Latitude\": 47.622845,\r\n    \"Longitude\": 8.931423\r\n  },\r\n  \"StreetAddress\": {\r\n    \"StreetNumber\": \"40\",\r\n    \"AddressLine1\": \"Rosenweg\",\r\n    \"AddressLine2\": \"\",\r\n    \"Route\": \"\",\r\n    \"Locality\": \"\",\r\n    \"Neighborhood\": \"\",\r\n    \"AdministrativeArea1\": \"Lanzenneunforn\",\r\n    \"AdministrativeArea2\": \"Herdern\",\r\n    \"PostalCode\": \"8506\",\r\n    \"CountryId\": \"CH\"\r\n  },\r\n  \"RentPerSquareMetre\": {\r\n    \"Amount\": 5.5,\r\n    \"CurrencyCode\": \"CHF\"\r\n  }\r\n}";

        var jsonOptions = new JsonSerializerOptions();
        jsonOptions.Converters.Add(new JsonStringEnumConverter());
        var action = () => JsonSerializer.Deserialize<VendingMachineDto>(rawJson, jsonOptions);

        action.Should().NotThrow();
    }
}