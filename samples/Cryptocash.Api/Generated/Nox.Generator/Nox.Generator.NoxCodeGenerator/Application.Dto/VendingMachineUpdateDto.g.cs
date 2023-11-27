// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachineUpdateDto : VendingMachineUpdateDtoBase
{

}

/// <summary>
/// Patch entity VendingMachine: Vending machine definition and related data.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class VendingMachinePatchDto: { { className} }
{

}

/// <summary>
/// Vending machine definition and related data
/// </summary>
public partial class VendingMachineUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.VendingMachine>
{
    /// <summary>
    /// Vending machine mac address     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "MacAddress is required")]
    
    public virtual System.String MacAddress { get; set; } = default!;
    /// <summary>
    /// Vending machine public ip     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "PublicIp is required")]
    
    public virtual System.String PublicIp { get; set; } = default!;
    /// <summary>
    /// Vending machine geo location     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "GeoLocation is required")]
    
    public virtual LatLongDto GeoLocation { get; set; } = default!;
    /// <summary>
    /// Vending machine street address     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "StreetAddress is required")]
    
    public virtual StreetAddressDto StreetAddress { get; set; } = default!;
    /// <summary>
    /// Vending machine serial number     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "SerialNumber is required")]
    
    public virtual System.String SerialNumber { get; set; } = default!;
    /// <summary>
    /// Vending machine installation area     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Decimal? InstallationFootPrint { get; set; }
    /// <summary>
    /// Landlord rent amount based on area of the vending machine installation     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual MoneyDto? RentPerSquareMetre { get; set; }
}