// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachine : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Vending machine unique identifier (Required).
    /// </summary>
    public DatabaseGuid Id { get; set; } = null!;

    /// <summary>
    /// Vending machine mac address (Required).
    /// </summary>
    public Nox.Types.MacAddress MacAddress { get; set; } = null!;

    /// <summary>
    /// Vending machine public ip (Required).
    /// </summary>
    public Nox.Types.IpAddress PublicIp { get; set; } = null!;

    /// <summary>
    /// Vending machine geo location (Required).
    /// </summary>
    public Nox.Types.LatLong GeoLocation { get; set; } = null!;

    /// <summary>
    /// Vending machine street address (Required).
    /// </summary>
    public Nox.Types.StreetAddress StreetAddress { get; set; } = null!;

    /// <summary>
    /// Vending machine serial number (Required).
    /// </summary>
    public Nox.Types.Text SerialNumber { get; set; } = null!;

    /// <summary>
    /// Vending machine installation area (Optional).
    /// </summary>
    public Nox.Types.Area? InstallationFootPrint { get; set; } = null!;

    /// <summary>
    /// Landlord rent amount based on area of the vending machine installation (Optional).
    /// </summary>
    public Nox.Types.Money? RentPerSquareMetre { get; set; } = null!;

    /// <summary>
    /// VendingMachine installed in ExactlyOne Countries
    /// </summary>
    public virtual Country VendingMachineInstallationCountry { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 VendingMachineInstallationCountryId { get; set; } = null!;

    /// <summary>
    /// VendingMachine contracted area leased by ExactlyOne LandLords
    /// </summary>
    public virtual LandLord VendingMachineContractedAreaLandLord { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity LandLord
    /// </summary>
    public Nox.Types.AutoNumber VendingMachineContractedAreaLandLordId { get; set; } = null!;

    /// <summary>
    /// VendingMachine related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> VendingMachineRelatedBookings { get; set; } = new();

    /// <summary>
    /// VendingMachine related to ZeroOrMany CashStockOrders
    /// </summary>
    public virtual List<CashStockOrder> VendingMachineRelatedCashStockOrders { get; set; } = new();

    /// <summary>
    /// VendingMachine required ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStock> VendingMachineRequiredMinimumCashStocks { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}