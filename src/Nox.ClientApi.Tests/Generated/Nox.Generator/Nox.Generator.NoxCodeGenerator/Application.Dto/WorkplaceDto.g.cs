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

public record WorkplaceKeyDto(System.Int64 keyId);

/// <summary>
/// Update Workplace
/// Workplace.
/// </summary>
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
    
        if (this.ReferenceNumber is not null)
            ExecuteActionAndCollectValidationExceptions("ReferenceNumber", () => DomainNamespace.WorkplaceMetadata.CreateReferenceNumber(this.ReferenceNumber.NonNullValue<System.String>()), result);
        if (this.Description is not null)
            ExecuteActionAndCollectValidationExceptions("Description", () => DomainNamespace.WorkplaceMetadata.CreateDescription(this.Description.NonNullValue<System.String>()), result); 
        if (this.Ownership is not null)
            ExecuteActionAndCollectValidationExceptions("Ownership", () => DomainNamespace.WorkplaceMetadata.CreateOwnership(this.Ownership.NonNullValue<System.Int32>()), result);
        if (this.Type is not null)
            ExecuteActionAndCollectValidationExceptions("Type", () => DomainNamespace.WorkplaceMetadata.CreateType(this.Type.NonNullValue<System.Int32>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Workplace unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Workplace Name     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Workplace Code     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.String? ReferenceNumber { get; set; }

    /// <summary>
    /// Workplace Description     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.String? Description { get; set; }

    /// <summary>
    /// The Formula     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.String? Greeting { get; set; }

    /// <summary>
    /// Workplace Ownership     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.Int32? Ownership { get; set; }

    /// <summary>
    /// Workplace Type     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.Int32? Type { get; set; }
    [NotMapped]
    public string? OwnershipName { get; set; } = default!;
    [NotMapped]
    public string? TypeName { get; set; } = default!;

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