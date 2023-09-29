﻿// Generated

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

public record StoreOwnerKeyDto(System.String keyId);

public partial class StoreOwnerDto : StoreOwnerDtoBase
{

}

/// <summary>
/// Store owners.
/// </summary>
public abstract class StoreOwnerDtoBase : EntityDtoBase, IEntityDto<StoreOwner>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            TryGetValidationExceptions("Name", () => ClientApi.Domain.StoreOwnerMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.TemporaryOwnerName is not null)
            TryGetValidationExceptions("TemporaryOwnerName", () => ClientApi.Domain.StoreOwnerMetadata.CreateTemporaryOwnerName(this.TemporaryOwnerName.NonNullValue<System.String>()), result);
        else
            result.Add("TemporaryOwnerName", new [] { "TemporaryOwnerName is Required." });
    
        if (this.VatNumber is not null)
            TryGetValidationExceptions("VatNumber", () => ClientApi.Domain.StoreOwnerMetadata.CreateVatNumber(this.VatNumber.NonNullValue<VatNumberDto>()), result);
        if (this.StreetAddress is not null)
            TryGetValidationExceptions("StreetAddress", () => ClientApi.Domain.StoreOwnerMetadata.CreateStreetAddress(this.StreetAddress.NonNullValue<StreetAddressDto>()), result);
        if (this.LocalGreeting is not null)
            TryGetValidationExceptions("LocalGreeting", () => ClientApi.Domain.StoreOwnerMetadata.CreateLocalGreeting(this.LocalGreeting.NonNullValue<TranslatedTextDto>()), result);
        if (this.Notes is not null)
            TryGetValidationExceptions("Notes", () => ClientApi.Domain.StoreOwnerMetadata.CreateNotes(this.Notes.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Owner Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Temporary Owner Name (Required).
    /// </summary>
    public System.String TemporaryOwnerName { get; set; } = default!;

    /// <summary>
    /// Vat Number (Optional).
    /// </summary>
    public VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Street Address (Optional).
    /// </summary>
    public StreetAddressDto? StreetAddress { get; set; }

    /// <summary>
    /// Owner Greeting (Optional).
    /// </summary>
    public TranslatedTextDto? LocalGreeting { get; set; }

    /// <summary>
    /// Notes (Optional).
    /// </summary>
    public System.String? Notes { get; set; }

    /// <summary>
    /// StoreOwner Set of stores that this owner owns ZeroOrMany Stores
    /// </summary>
    public virtual List<StoreDto> Stores { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}