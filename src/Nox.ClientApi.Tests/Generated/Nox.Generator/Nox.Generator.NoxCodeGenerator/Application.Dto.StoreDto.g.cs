// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record StoreKeyDto(System.Guid keyId);

public partial class StoreDto : StoreDtoBase
{

}

/// <summary>
/// Stores.
/// </summary>
public abstract class StoreDtoBase : EntityDtoBase, IEntityDto<Store>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => ClientApi.Domain.StoreMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Address is not null)
            ExecuteActionAndCollectValidationExceptions("Address", () => ClientApi.Domain.StoreMetadata.CreateAddress(this.Address.NonNullValue<StreetAddressDto>()), result);
        else
            result.Add("Address", new [] { "Address is Required." });
    
        if (this.Location is not null)
            ExecuteActionAndCollectValidationExceptions("Location", () => ClientApi.Domain.StoreMetadata.CreateLocation(this.Location.NonNullValue<LatLongDto>()), result);
        else
            result.Add("Location", new [] { "Location is Required." });
    
        if (this.OpeningDay is not null)
            ExecuteActionAndCollectValidationExceptions("OpeningDay", () => ClientApi.Domain.StoreMetadata.CreateOpeningDay(this.OpeningDay.NonNullValue<System.DateTimeOffset>()), result);

        return result;
    }
    #endregion

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Street Address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// Location (Required).
    /// </summary>
    public LatLongDto Location { get; set; } = default!;

    /// <summary>
    /// Opening day (Optional).
    /// </summary>
    public System.DateTimeOffset? OpeningDay { get; set; }

    /// <summary>
    /// Store Owner of the Store ZeroOrOne StoreOwners
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? OwnershipId { get; set; } = default!;
    public virtual StoreOwnerDto? Ownership { get; set; } = null!;

    /// <summary>
    /// Store License that this store uses ZeroOrOne StoreLicenses
    /// </summary>
    public virtual StoreLicenseDto? License { get; set; } = null!;

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddressDto? VerifiedEmails { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}