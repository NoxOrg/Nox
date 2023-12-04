// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Stores.
/// </summary>
public partial class StoreCreateDto : StoreCreateDtoBase
{

}

/// <summary>
/// Stores.
/// </summary>
public abstract class StoreCreateDtoBase : IEntityDto<DomainNamespace.Store>
{/// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Guid Id { get; set; } = default!;
    /// <summary>
    /// Store Name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Street Address     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Location     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Location is required")]
    
    public virtual LatLongDto Location { get; set; } = default!;
    /// <summary>
    /// Opening day     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.DateTimeOffset? OpeningDay { get; set; }
    /// <summary>
    /// Store Status     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.Int32? Status { get; set; }

    /// <summary>
    /// Store Owner of the Store ZeroOrOne StoreOwners
    /// </summary>
    public System.String? StoreOwnerId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual StoreOwnerCreateDto? StoreOwner { get; set; } = default!;

    /// <summary>
    /// Store License that this store uses ZeroOrOne StoreLicenses
    /// </summary>
    public System.Int64? StoreLicenseId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual StoreLicenseCreateDto? StoreLicense { get; set; } = default!;

    /// <summary>
    /// Store clients of the store ZeroOrMany Clients
    /// </summary>
    public virtual List<System.Guid> ClientsId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<ClientCreateDto> Clients { get; set; } = new();

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddressUpsertDto? EmailAddress { get; set; } = null!;
}