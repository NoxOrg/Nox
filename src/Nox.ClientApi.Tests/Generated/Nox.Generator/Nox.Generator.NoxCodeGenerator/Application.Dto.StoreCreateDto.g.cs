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

public partial class StoreCreateDto : StoreCreateDtoBase
{

}

/// <summary>
/// Stores.
/// </summary>
public abstract class StoreCreateDtoBase : IEntityDto<Store>
{/// <summary>
    ///  (Optional).
    /// </summary>
    public System.Guid Id { get; set; } = default!;
    /// <summary>
    /// Store Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Street Address (Required).
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Location (Required).
    /// </summary>
    [Required(ErrorMessage = "Location is required")]
    
    public virtual LatLongDto Location { get; set; } = default!;
    /// <summary>
    /// Opening day (Optional).
    /// </summary>
    public virtual System.DateTimeOffset? OpeningDay { get; set; }

    /// <summary>
    /// Store Owner of the Store ZeroOrOne StoreOwners
    /// </summary>
    public System.String? OwnershipId { get; set; } = default!;
    public virtual StoreOwnerCreateDto? Ownership { get; set; } = default!;

    /// <summary>
    /// Store License that this store uses ZeroOrOne StoreLicenses
    /// </summary>
    public System.Int64? LicenseId { get; set; } = default!;
    public virtual StoreLicenseCreateDto? License { get; set; } = default!;

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddressCreateDto? VerifiedEmails { get; set; } = null!;
}