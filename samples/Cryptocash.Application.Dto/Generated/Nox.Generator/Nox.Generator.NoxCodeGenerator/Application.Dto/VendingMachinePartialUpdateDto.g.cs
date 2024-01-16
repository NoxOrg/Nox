// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;



/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachinePartialUpdateDto : VendingMachinePartialUpdateDtoBase
{

}

/// <summary>
/// Vending machine definition and related data
/// </summary>
public partial class VendingMachinePartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Vending machine mac address
    /// </summary>
    public virtual System.String MacAddress { get; set; } = default!;
    /// <summary>
    /// Vending machine public ip
    /// </summary>
    public virtual System.String PublicIp { get; set; } = default!;
    /// <summary>
    /// Vending machine geo location
    /// </summary>
    public virtual LatLongDto GeoLocation { get; set; } = default!;
    /// <summary>
    /// Vending machine street address
    /// </summary>
    public virtual StreetAddressDto StreetAddress { get; set; } = default!;
    /// <summary>
    /// Vending machine serial number
    /// </summary>
    public virtual System.String SerialNumber { get; set; } = default!;
    /// <summary>
    /// Vending machine installation area
    /// </summary>
    public virtual System.Decimal? InstallationFootPrint { get; set; }
    /// <summary>
    /// Landlord rent amount based on area of the vending machine installation
    /// </summary>
    public virtual MoneyDto? RentPerSquareMetre { get; set; }
}