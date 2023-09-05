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
public partial class VendingMachine : AuditableEntityBase
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
    public virtual Country Country { get; set; } = null!;

    public Country VendingMachineInstallationCountry => Country;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CountryId { get; set; } = null!;

    /// <summary>
    /// VendingMachine contracted area leased by ExactlyOne LandLords
    /// </summary>
    public virtual LandLord LandLord { get; set; } = null!;

    public LandLord VendingMachineContractedAreaLandLord => LandLord;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity LandLord
    /// </summary>
    public Nox.Types.DatabaseNumber LandLordId { get; set; } = null!;

    /// <summary>
    /// VendingMachine related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> Bookings { get; set; } = new();

    public List<Booking> VendingMachineRelatedBookings => Bookings;

    /// <summary>
    /// VendingMachine related to ZeroOrMany CashStockOrders
    /// </summary>
    public virtual List<CashStockOrder> CashStockOrders { get; set; } = new();

    public List<CashStockOrder> VendingMachineRelatedCashStockOrders => CashStockOrders;

    /// <summary>
    /// VendingMachine required ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStock> MinimumCashStocks { get; set; } = new();

    public List<MinimumCashStock> VendingMachineRequiredMinimumCashStocks => MinimumCashStocks;
}