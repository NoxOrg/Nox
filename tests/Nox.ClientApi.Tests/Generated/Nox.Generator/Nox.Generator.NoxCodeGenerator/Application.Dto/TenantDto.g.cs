﻿// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace ClientApi.Application.Dto;

public record TenantKeyDto(System.UInt32 keyId);

/// <summary>
/// Update Tenant
/// Tenant.
/// </summary>
public partial class TenantDto : TenantDtoBase
{

}

/// <summary>
/// Tenant.
/// </summary>
public abstract class TenantDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            CollectValidationExceptions("Name", () => TenantMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Status is not null)
            CollectValidationExceptions("Status", () => TenantMetadata.CreateStatus(this.Status.NonNullValue<System.Int32>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.UInt32 Id { get; set; } = default!;

    /// <summary>
    /// Teanant Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Tenant Status     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Int32? Status { get; set; }
    public string? StatusName { get; set; } = default!;

    /// <summary>
    /// Tenant Workplaces where the tenant is active ZeroOrMany Workplaces
    /// </summary>
    public virtual List<WorkplaceDto> Workplaces { get; set; } = new();

    /// <summary>
    /// Tenant Brands owned by the tenant ZeroOrMany TenantBrands
    /// </summary>
    public virtual List<TenantBrandDto> TenantBrands { get; set; } = new();

    /// <summary>
    /// Tenant Contact information for the tenant ZeroOrOne TenantContacts
    /// </summary>
    public virtual TenantContactDto? TenantContact { get; set; } = null!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}