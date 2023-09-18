// Generated

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Ui.Domain;

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachine : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Vending machine unique identifier (Required).
    /// </summary>
    //[JsonPropertyName(nameof(Id))]
    //public DatabaseGuid Id { get; set; } = null!;

    /// <summary>
    /// Vending machine mac address (Required).
    /// </summary>
    [JsonPropertyName(nameof(MacAddress))]
    public string MacAddress { get; set; } = null!;

    /// <summary>
    /// Vending machine public ip (Required).
    /// </summary>
    [JsonPropertyName(nameof(PublicIp))]
    public string PublicIp { get; set; } = null!;

    /// <summary>
    /// Vending machine geo location (Required).
    /// </summary>
    //[JsonPropertyName(nameof(GeoLocation))]
    //public Nox.Types.LatLong GeoLocation { get; set; } = null!;

    /// <summary>
    /// Vending machine street address (Required).
    /// </summary>
    //[JsonPropertyName(nameof(StreetAddress))]
    //public Nox.Types.StreetAddress StreetAddress { get; set; } = null!;

    /// <summary>
    /// Vending machine serial number (Required).
    /// </summary>
    [JsonPropertyName(nameof(SerialNumber))]
    public string SerialNumber { get; set; } = null!;

    /// <summary>
    /// Vending machine installation area (Optional).
    /// </summary>
    //[JsonPropertyName(nameof(InstallationFootPrint))]
    //public Nox.Types.Area? InstallationFootPrint { get; set; } = null!;

    /// <summary>
    /// Landlord rent amount based on area of the vending machine installation (Optional).
    /// </summary>
    //[JsonPropertyName(nameof(RentPerSquareMetre))]
    //public Nox.Types.Money? RentPerSquareMetre { get; set; } = null!;

    /// <summary>
    /// VendingMachine installed in ExactlyOne Countries
    /// </summary>
    //[JsonPropertyName(nameof(VendingMachineInstallationCountry))]
    //public virtual Country VendingMachineInstallationCountry { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    //[JsonPropertyName(nameof(VendingMachineInstallationCountryId))]
    //public Nox.Types.CountryCode2 VendingMachineInstallationCountryId { get; set; } = null!;

    /// <summary>
    /// VendingMachine contracted area leased by ExactlyOne LandLords
    /// </summary>
    //[JsonPropertyName(nameof(VendingMachineContractedAreaLandLord))]
    //public virtual LandLord VendingMachineContractedAreaLandLord { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity LandLord
    /// </summary>
    //[JsonPropertyName(nameof(VendingMachineContractedAreaLandLordId))]
    //public Nox.Types.AutoNumber VendingMachineContractedAreaLandLordId { get; set; } = null!;

    /// <summary>
    /// VendingMachine related to ZeroOrMany Bookings
    /// </summary>
    //[JsonPropertyName(nameof(VendingMachineRelatedBookings))]
    //public virtual List<Booking> VendingMachineRelatedBookings { get; set; } = new();

    /// <summary>
    /// VendingMachine related to ZeroOrMany CashStockOrders
    /// </summary>
    //[JsonPropertyName(nameof(VendingMachineRelatedCashStockOrders))]
    //public virtual List<CashStockOrder> VendingMachineRelatedCashStockOrders { get; set; } = new();

    /// <summary>
    /// VendingMachine required ZeroOrMany MinimumCashStocks
    /// </summary>
    //[JsonPropertyName(nameof(VendingMachineRequiredMinimumCashStocks))]
    //public virtual List<MinimumCashStock> VendingMachineRequiredMinimumCashStocks { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    [JsonPropertyName(nameof(Etag))]
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}