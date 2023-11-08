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
/// Stores
/// </summary>
public partial class StoreUpdateDto : IEntityDto<DomainNamespace.Store>
{
    /// <summary>
    /// Store Name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Street Address 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Location 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Location is required")]
    
    public LatLongDto Location { get; set; } = default!;
    /// <summary>
    /// Opening day 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.DateTimeOffset? OpeningDay { get; set; }
    /// <summary>
    /// Store Status 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.Int32? Status { get; set; }

    /// <summary>
    /// Store Owner of the Store ZeroOrOne StoreOwners
    /// </summary>
    
    public System.String? StoreOwnerId { get; set; } = default!;

    /// <summary>
    /// Store License that this store uses ZeroOrOne StoreLicenses
    /// </summary>
    
    public System.Int64? StoreLicenseId { get; set; } = default!;
    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public EmailAddressUpdateDto? EmailAddress { get; set; } = null!;
}