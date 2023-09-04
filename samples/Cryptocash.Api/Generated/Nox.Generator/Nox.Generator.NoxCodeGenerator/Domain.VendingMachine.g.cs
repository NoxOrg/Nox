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
    /// VendingMachine Vending machine's country ExactlyOne Countries
    /// </summary>
    public virtual Country Country { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CountryId { get; set; } = null!;

    /// <summary>
    /// VendingMachine Area of the vending machine installation landlord ExactlyOne LandLords
    /// </summary>
    public virtual LandLord LandLord { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity LandLord
    /// </summary>
    public Nox.Types.DatabaseNumber LandLordId { get; set; } = null!;

    /// <summary>
    /// VendingMachine Booking's vending machine ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> Booking { get; set; } = new();

    /// <summary>
    /// VendingMachine Order's vending machine ZeroOrMany VendingMachineOrders
    /// </summary>
    public virtual List<VendingMachineOrder> VendingMachineOrder { get; set; } = new();

    /// <summary>
    /// VendingMachine Vending machine's minimum cash stock ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStock> MinimumCashStock { get; set; } = new();
}