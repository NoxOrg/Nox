// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record StoreKeyDto(System.Guid keyId);

/// <summary>
/// Update Store
/// Stores.
/// </summary>
public partial class StoreDto : StoreDtoBase
{

}

/// <summary>
/// Stores.
/// </summary>
public abstract class StoreDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Store>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.StoreMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Address is not null)
            ExecuteActionAndCollectValidationExceptions("Address", () => DomainNamespace.StoreMetadata.CreateAddress(this.Address.NonNullValue<StreetAddressDto>()), result);
        else
            result.Add("Address", new [] { "Address is Required." });
    
        if (this.Location is not null)
            ExecuteActionAndCollectValidationExceptions("Location", () => DomainNamespace.StoreMetadata.CreateLocation(this.Location.NonNullValue<LatLongDto>()), result);
        else
            result.Add("Location", new [] { "Location is Required." });
    
        if (this.OpeningDay is not null)
            ExecuteActionAndCollectValidationExceptions("OpeningDay", () => DomainNamespace.StoreMetadata.CreateOpeningDay(this.OpeningDay.NonNullValue<System.DateTimeOffset>()), result);
        if (this.Status is not null)
            ExecuteActionAndCollectValidationExceptions("Status", () => DomainNamespace.StoreMetadata.CreateStatus(this.Status.NonNullValue<System.Int32>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Store Name     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Street Address     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// Location     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public LatLongDto Location { get; set; } = default!;

    /// <summary>
    /// Opening day     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.DateTimeOffset? OpeningDay { get; set; }

    /// <summary>
    /// Store Status     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.Int32? Status { get; set; }
    [NotMapped]
    public string? StatusName { get; set; } = default!;

    /// <summary>
    /// Store Owner of the Store ZeroOrOne StoreOwners
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? StoreOwnerId { get; set; } = default!;
    public virtual StoreOwnerDto? StoreOwner { get; set; } = null!;

    /// <summary>
    /// Store License that this store uses ZeroOrOne StoreLicenses
    /// </summary>
    public virtual StoreLicenseDto? StoreLicense { get; set; } = null!;

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddressDto? EmailAddress { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}