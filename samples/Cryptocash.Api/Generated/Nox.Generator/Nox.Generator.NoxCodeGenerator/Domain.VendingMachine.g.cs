// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace CryptocashApi.Domain;

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachine : AuditableEntityBase
{
    /// <summary>
    /// The vending machine unique identifier (Required).
    /// </summary>
    public DatabaseGuid Id { get; set; } = null!;

    /// <summary>
    /// The mac address of the vending machine (Required).
    /// </summary>
    public Nox.Types.MacAddress MacAddress { get; set; } = null!;

    /// <summary>
    /// The public ip of the vending machine (Required).
    /// </summary>
    public Nox.Types.IpAddress PublicIp { get; set; } = null!;

    /// <summary>
    /// The public ip of the vending machine (Required).
    /// </summary>
    public Nox.Types.LatLong GeoLocation { get; set; } = null!;

    /// <summary>
    /// The address of the vending machine (Required).
    /// </summary>
    public Nox.Types.StreetAddress StreetAddress { get; set; } = null!;

    /// <summary>
    /// The serial number of the vending machine (Required).
    /// </summary>
    public Nox.Types.Text SerialNumber { get; set; } = null!;

    /// <summary>
    /// The area of the vending machine installation (Optional).
    /// </summary>
    public Nox.Types.Area? InstallationFootPrint { get; set; } = null!;

    /// <summary>
    /// The land lord rent amount related to the area of the vending machine installation (Optional).
    /// </summary>
    public Nox.Types.Money? RentPerSquareMetre { get; set; } = null!;

    /// <summary>
    /// VendingMachine The country of the vending machine ExactlyOne Countries
    /// </summary>
    public virtual Country Country { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CountryId { get; set; } = null!;

    /// <summary>
    /// VendingMachine The Land Lord related to the area of the vending machine installation ExactlyOne LandLords
    /// </summary>
    public virtual LandLord LandLord { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity LandLord
    /// </summary>
    public Nox.Types.DatabaseNumber LandLordId { get; set; } = null!;

    /// <summary>
    /// VendingMachine The booking's related vending machine ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> Bookings { get; set; } = new();

    public List<Booking> Booking => Bookings;

    /// <summary>
    /// VendingMachine The order's related vending machine ZeroOrMany VendingMachineOrders
    /// </summary>
    public virtual List<VendingMachineOrder> VendingMachineOrders { get; set; } = new();

    public List<VendingMachineOrder> VendingMachineOrder => VendingMachineOrders;

    /// <summary>
    /// VendingMachine The related vending machine ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStock> MinimumCashStocks { get; set; } = new();

    public List<MinimumCashStock> MinimumCashStock => MinimumCashStocks;
}