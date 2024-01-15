// Generated

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
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.TenantBrandMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Description is not null)
            ExecuteActionAndCollectValidationExceptions("Description", () => DomainNamespace.TenantBrandMetadata.CreateDescription(this.Description.NonNullValue<System.String>()), result);
        else
            result.Add("Description", new [] { "Description is Required." });
    

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
}