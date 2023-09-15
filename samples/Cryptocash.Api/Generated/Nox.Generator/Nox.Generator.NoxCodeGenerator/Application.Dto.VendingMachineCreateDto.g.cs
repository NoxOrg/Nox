// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class VendingMachineCreateDto: VendingMachineCreateDtoBase
{

}

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public abstract class VendingMachineCreateDtoBase : IEntityCreateDto<VendingMachine>
{
    /// <summary>
    /// Vending machine unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.Guid Id { get; set; } = default!;    
    /// <summary>
    /// Vending machine mac address (Required).
    /// </summary>
    [Required(ErrorMessage = "MacAddress is required")]
    
    public virtual System.String MacAddress { get; set; } = default!;    
    /// <summary>
    /// Vending machine public ip (Required).
    /// </summary>
    [Required(ErrorMessage = "PublicIp is required")]
    
    public virtual System.String PublicIp { get; set; } = default!;    
    /// <summary>
    /// Vending machine geo location (Required).
    /// </summary>
    [Required(ErrorMessage = "GeoLocation is required")]
    
    public virtual LatLongDto GeoLocation { get; set; } = default!;    
    /// <summary>
    /// Vending machine street address (Required).
    /// </summary>
    [Required(ErrorMessage = "StreetAddress is required")]
    
    public virtual StreetAddressDto StreetAddress { get; set; } = default!;    
    /// <summary>
    /// Vending machine serial number (Required).
    /// </summary>
    [Required(ErrorMessage = "SerialNumber is required")]
    
    public virtual System.String SerialNumber { get; set; } = default!;    
    /// <summary>
    /// Vending machine installation area (Optional).
    /// </summary>
    public virtual System.Decimal? InstallationFootPrint { get; set; }    
    /// <summary>
    /// Landlord rent amount based on area of the vending machine installation (Optional).
    /// </summary>
    public virtual MoneyDto? RentPerSquareMetre { get; set; }

    /// <summary>
    /// VendingMachine installed in ExactlyOne Countries
    /// </summary>
    [Required(ErrorMessage = "VendingMachineInstallationCountry is required")]
    public virtual CountryCreateDto VendingMachineInstallationCountry { get; set; } = null!;

    /// <summary>
    /// VendingMachine contracted area leased by ExactlyOne LandLords
    /// </summary>
    [Required(ErrorMessage = "VendingMachineContractedAreaLandLord is required")]
    public virtual LandLordCreateDto VendingMachineContractedAreaLandLord { get; set; } = null!;

    /// <summary>
    /// VendingMachine related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<BookingCreateDto> VendingMachineRelatedBookings { get; set; } = new();

    /// <summary>
    /// VendingMachine related to ZeroOrMany CashStockOrders
    /// </summary>
    public virtual List<CashStockOrderCreateDto> VendingMachineRelatedCashStockOrders { get; set; } = new();

    /// <summary>
    /// VendingMachine required ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStockCreateDto> VendingMachineRequiredMinimumCashStocks { get; set; } = new();
}