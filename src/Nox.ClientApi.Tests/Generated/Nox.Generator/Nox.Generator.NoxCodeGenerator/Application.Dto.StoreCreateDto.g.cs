// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Stores.
/// </summary>
public partial class StoreCreateDto : IEntityCreateDto <Store>
{    
    /// <summary>
    /// Store Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;    
    /// <summary>
    /// Street Address (Required).
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public StreetAddressDto Address { get; set; } = default!;    
    /// <summary>
    /// Location (Required).
    /// </summary>
    [Required(ErrorMessage = "Location is required")]
    
    public LatLongDto Location { get; set; } = default!;

    /// <summary>
    /// Store Store owner relationship ZeroOrOne StoreOwners
    /// </summary>
    
    public System.String? OwnerRelId { get; set; } = default!;

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddressCreateDto? EmailAddress { get; set; } = null!;   
}