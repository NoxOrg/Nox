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

public record TenantBrandKeyDto(System.Int64 keyId);

/// <summary>
/// Update TenantBrand
/// Tenant Brand.
/// </summary>
public partial class TenantBrandDto : TenantBrandDtoBase
{

}

/// <summary>
/// Tenant Brand.
/// </summary>
public abstract class TenantBrandDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            CollectValidationExceptions("Name", () => TenantBrandMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Description is not null)
            CollectValidationExceptions("Description", () => TenantBrandMetadata.CreateDescription(this.Description.NonNullValue<System.String>()), result);
        else
            result.Add("Description", new [] { "Description is Required." });
    
        if (this.Status is not null)
            CollectValidationExceptions("Status", () => TenantBrandMetadata.CreateStatus(this.Status.NonNullValue<System.Int32>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Teanant Brand Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Teanant Brand Description     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Description { get; set; } = default!;

    /// <summary>
    /// Tenant Brand Status     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Int32? Status { get; set; }
    public string? StatusName { get; set; } = default!;
}