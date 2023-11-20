﻿// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = ClientApi.Domain;

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
public abstract class TenantDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Tenant>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.TenantMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    

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
    /// Tenant Workplaces where the tenant is active ZeroOrMany Workplaces
    /// </summary>
    public virtual List<WorkplaceDto> Workplaces { get; set; } = new();

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}