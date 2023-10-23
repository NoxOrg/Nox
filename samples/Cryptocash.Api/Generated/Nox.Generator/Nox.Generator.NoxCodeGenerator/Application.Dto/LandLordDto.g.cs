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
using Cryptocash.Domain;
using LandLordEntity = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Dto;

public record LandLordKeyDto(System.Int64 keyId);

public partial class LandLordDto : LandLordDtoBase
{

}

/// <summary>
/// Landlord related data.
/// </summary>
public abstract class LandLordDtoBase : EntityDtoBase, IEntityDto<LandLordEntity>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => Cryptocash.Domain.LandLordMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Address is not null)
            ExecuteActionAndCollectValidationExceptions("Address", () => Cryptocash.Domain.LandLordMetadata.CreateAddress(this.Address.NonNullValue<StreetAddressDto>()), result);
        else
            result.Add("Address", new [] { "Address is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// Landlord unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Landlord name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Landlord's street address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// LandLord leases an area to house ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineDto> ContractedAreasForVendingMachines { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}