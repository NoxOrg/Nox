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

public record WorkplaceKeyDto(System.UInt32 keyId);

public partial class WorkplaceDto : WorkplaceDtoBase
{

}

/// <summary>
/// Workplace.
/// </summary>
public abstract class WorkplaceDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Workplace>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.WorkplaceMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Description is not null)
            ExecuteActionAndCollectValidationExceptions("Description", () => DomainNamespace.WorkplaceMetadata.CreateDescription(this.Description.NonNullValue<System.String>()), result); 

        return result;
    }
    #endregion

    /// <summary>
    /// Workplace unique identifier
    /// </summary>    
    public System.UInt32 Id { get; set; } = default!;

    /// <summary>
    /// Workplace Name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Workplace Description 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? Description { get; set; }

    /// <summary>
    /// The Formula 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? Greeting { get; set; }

    /// <summary>
    /// Workplace Workplace country ZeroOrOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64? CountryId { get; set; } = default!;
    public virtual CountryDto? Country { get; set; } = null!;

    /// <summary>
    /// Workplace Actve Tenants in the workplace ZeroOrMany Tenants
    /// </summary>
    public virtual List<TenantDto> Tenants { get; set; } = new();

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}