// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class VendingMachineCreateDto : VendingMachineCreateDtoBase
{

}

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public abstract class VendingMachineCreateDtoBase : IEntityDto<DomainNamespace.VendingMachine>
{/// <summary>
    /// Vending machine unique identifier 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.Guid Id { get; set; } = default!;
    /// <summary>
    /// Vending machine mac address 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "MacAddress is required")]
    
    public virtual System.String MacAddress { get; set; } = default!;
    /// <summary>
    /// Vending machine public ip 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "PublicIp is required")]
    
    public virtual System.String PublicIp { get; set; } = default!;
    /// <summary>
    /// Vending machine geo location 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "GeoLocation is required")]
    
    public virtual LatLongDto GeoLocation { get; set; } = default!;
    /// <summary>
    /// Vending machine street address 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "StreetAddress is required")]
    
    public virtual StreetAddressDto StreetAddress { get; set; } = default!;
    /// <summary>
    /// Vending machine serial number 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "SerialNumber is required")]
    
    public virtual System.String SerialNumber { get; set; } = default!;
    /// <summary>
    /// Vending machine installation area 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Decimal? InstallationFootPrint { get; set; }
    /// <summary>
    /// Landlord rent amount based on area of the vending machine installation 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual MoneyDto? RentPerSquareMetre { get; set; }

    /// <summary>
    /// VendingMachine installed in ExactlyOne Countries
    /// </summary>
    public System.String? CountryId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CountryCreateDto? Country { get; set; } = default!;

    /// <summary>
    /// VendingMachine contracted area leased by ExactlyOne LandLords
    /// </summary>
    public System.Int64? LandLordId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual LandLordCreateDto? LandLord { get; set; } = default!;

    /// <summary>
    /// VendingMachine related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<System.Guid> BookingsId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<BookingCreateDto> Bookings { get; set; } = new();

    /// <summary>
    /// VendingMachine related to ZeroOrMany CashStockOrders
    /// </summary>
    public virtual List<System.Int64> CashStockOrdersId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<CashStockOrderCreateDto> CashStockOrders { get; set; } = new();

    /// <summary>
    /// VendingMachine required ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<System.Int64> MinimumCashStocksId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<MinimumCashStockCreateDto> MinimumCashStocks { get; set; } = new();
}