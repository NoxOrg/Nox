// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Stores.
/// </summary>
public partial class StoreUpdateDto : StoreUpdateDtoBase
{

}

/// <summary>
/// Stores
/// </summary>
public partial class StoreUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Store Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Street Address     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto? Address { get; set; }
    /// <summary>
    /// Location     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Location is required")]
    
    public virtual LatLongDto? Location { get; set; }
    /// <summary>
    /// Opening day     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.DateTimeOffset? OpeningDay { get; set; }
    /// <summary>
    /// Store Status     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Int32? Status { get; set; }
    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddressUpsertDto? EmailAddress { get; set; } = null!;
}