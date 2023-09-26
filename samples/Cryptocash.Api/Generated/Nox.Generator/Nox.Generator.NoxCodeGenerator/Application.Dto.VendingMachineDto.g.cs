// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record VendingMachineKeyDto(System.Guid keyId);

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachineDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("MacAddress", () => Cryptocash.Domain.VendingMachine.CreateMacAddress(this.MacAddress), result);
        ValidateField("PublicIp", () => Cryptocash.Domain.VendingMachine.CreatePublicIp(this.PublicIp), result);
        ValidateField("GeoLocation", () => Cryptocash.Domain.VendingMachine.CreateGeoLocation(this.GeoLocation), result);
        ValidateField("StreetAddress", () => Cryptocash.Domain.VendingMachine.CreateStreetAddress(this.StreetAddress), result);
        ValidateField("SerialNumber", () => Cryptocash.Domain.VendingMachine.CreateSerialNumber(this.SerialNumber), result);
        if (this.InstallationFootPrint is not null)
            ValidateField("InstallationFootPrint", () => Cryptocash.Domain.VendingMachine.CreateInstallationFootPrint(this.InstallationFootPrint.NonNullValue<System.Decimal>()), result);
        if (this.RentPerSquareMetre is not null)
            ValidateField("RentPerSquareMetre", () => Cryptocash.Domain.VendingMachine.CreateRentPerSquareMetre(this.RentPerSquareMetre.NonNullValue<MoneyDto>()), result);

        return result;
    }

    private void ValidateField<T>(string fieldName, Func<T> action, Dictionary<string, IEnumerable<string>> result)
    {
        try
        {
            action();
        }
        catch (TypeValidationException ex)
        {
            result.Add(fieldName, ex.Errors.Select(x => x.ErrorMessage));
        }
        catch (NullReferenceException)
        {
            result.Add(fieldName, new List<string> { $"{fieldName} is Required." });
        }
    }
    #endregion

    /// <summary>
    /// Vending machine unique identifier (Required).
    /// </summary>
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Vending machine mac address (Required).
    /// </summary>
    public System.String MacAddress { get; set; } = default!;

    /// <summary>
    /// Vending machine public ip (Required).
    /// </summary>
    public System.String PublicIp { get; set; } = default!;

    /// <summary>
    /// Vending machine geo location (Required).
    /// </summary>
    public LatLongDto GeoLocation { get; set; } = default!;

    /// <summary>
    /// Vending machine street address (Required).
    /// </summary>
    public StreetAddressDto StreetAddress { get; set; } = default!;

    /// <summary>
    /// Vending machine serial number (Required).
    /// </summary>
    public System.String SerialNumber { get; set; } = default!;

    /// <summary>
    /// Vending machine installation area (Optional).
    /// </summary>
    public System.Decimal? InstallationFootPrint { get; set; }

    /// <summary>
    /// Landlord rent amount based on area of the vending machine installation (Optional).
    /// </summary>
    public MoneyDto? RentPerSquareMetre { get; set; }

    /// <summary>
    /// VendingMachine installed in ExactlyOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? VendingMachineInstallationCountryId { get; set; } = default!;
    public virtual CountryDto? VendingMachineInstallationCountry { get; set; } = null!;

    /// <summary>
    /// VendingMachine contracted area leased by ExactlyOne LandLords
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64? VendingMachineContractedAreaLandLordId { get; set; } = default!;
    public virtual LandLordDto? VendingMachineContractedAreaLandLord { get; set; } = null!;

    /// <summary>
    /// VendingMachine related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<BookingDto> VendingMachineRelatedBookings { get; set; } = new();

    /// <summary>
    /// VendingMachine related to ZeroOrMany CashStockOrders
    /// </summary>
    public virtual List<CashStockOrderDto> VendingMachineRelatedCashStockOrders { get; set; } = new();

    /// <summary>
    /// VendingMachine required ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStockDto> VendingMachineRequiredMinimumCashStocks { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}