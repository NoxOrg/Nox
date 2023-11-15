// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

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
public partial class StoreUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Store>
{
    /// <summary>
    /// Store Name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Street Address 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Location 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Location is required")]
    
    public virtual LatLongDto Location { get; set; } = default!;
    /// <summary>
    /// Opening day 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.DateTimeOffset? OpeningDay { get; set; }
    /// <summary>
    /// Store Status 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.Int32? Status { get; set; }
    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddressUpdateDto? EmailAddress { get; set; } = null!;
}