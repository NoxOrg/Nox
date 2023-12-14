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

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachineCreateDto : VendingMachineCreateDtoBase
{

}

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public abstract class VendingMachineCreateDtoBase : IEntityDto<DomainNamespace.VendingMachine>
{/// <summary>
    /// Vending machine unique identifier     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Guid? Id { get; set; }
    /// <summary>
    /// Vending machine mac address     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "MacAddress is required")]
    
    public virtual System.String? MacAddress { get; set; }
    /// <summary>
    /// Vending machine public ip     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "PublicIp is required")]
    
    public virtual System.String? PublicIp { get; set; }
    /// <summary>
    /// Vending machine geo location     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "GeoLocation is required")]
    
    public virtual LatLongDto? GeoLocation { get; set; }
    /// <summary>
    /// Vending machine street address     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "StreetAddress is required")]
    
    public virtual StreetAddressDto? StreetAddress { get; set; }
    /// <summary>
    /// Vending machine serial number     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "SerialNumber is required")]
    
    public virtual System.String? SerialNumber { get; set; }
    /// <summary>
    /// Vending machine installation area     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.Decimal? InstallationFootPrint { get; set; }
    /// <summary>
    /// Landlord rent amount based on area of the vending machine installation     
    /// </summary>
    /// <remarks>Optional</remarks>
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
    public System.Guid? LandLordId { get; set; } = default!;
    
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