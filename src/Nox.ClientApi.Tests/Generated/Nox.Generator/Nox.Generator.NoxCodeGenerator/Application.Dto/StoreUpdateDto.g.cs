// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClientApi.Domain;

using StoreEntity = ClientApi.Domain.Store;
namespace ClientApi.Application.Dto;

/// <summary>
/// Stores.
/// </summary>
public partial class StoreUpdateDto : IEntityDto<StoreEntity>
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
    /// Opening day (Optional).
    /// </summary>
    public System.DateTimeOffset? OpeningDay { get; set; }

    /// <summary>
    /// Store Owner of the Store ZeroOrOne StoreOwners
    /// </summary>
    
    public System.String? OwnershipId { get; set; } = default!;
    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public EmailAddressUpdateDto? EmailAddress { get; set; } = null!;
}