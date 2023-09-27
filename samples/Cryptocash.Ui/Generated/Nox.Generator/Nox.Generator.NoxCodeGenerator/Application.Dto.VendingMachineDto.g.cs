// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;

namespace Cryptocash.Ui.Application.Dto;

public record VendingMachineKeyDto(System.Guid keyId);

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachineDto
{

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
    //public StreetAddressDto StreetAddress { get; set; } = default!;

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
    //public MoneyDto? RentPerSquareMetre { get; set; }

    /// <summary>
    /// VendingMachine installed in ExactlyOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String VendingMachineInstallationCountryId { get; set; } = default!;
    public virtual CountryDto VendingMachineInstallationCountry { get; set; } = null!;

    /// <summary>
    /// VendingMachine contracted area leased by ExactlyOne LandLords
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64 VendingMachineContractedAreaLandLordId { get; set; } = default!;
    public virtual LandLordDto VendingMachineContractedAreaLandLord { get; set; } = null!;

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