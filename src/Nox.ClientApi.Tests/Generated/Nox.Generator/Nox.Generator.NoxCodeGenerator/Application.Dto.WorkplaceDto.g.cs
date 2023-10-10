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
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Dto;

public record WorkplaceKeyDto(System.UInt32 keyId);

public partial class WorkplaceDto : WorkplaceDtoBase
{

}

/// <summary>
/// Workplace.
/// </summary>
public abstract class WorkplaceDtoBase : EntityDtoBase, IEntityDto<WorkplaceEntity>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => ClientApi.Domain.WorkplaceMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Description is not null)
            ExecuteActionAndCollectValidationExceptions("Description", () => ClientApi.Domain.WorkplaceMetadata.CreateDescription(this.Description.NonNullValue<System.String>()), result); 

        return result;
    }
    #endregion

    /// <summary>
    /// Workplace unique identifier (Required).
    /// </summary>
    public System.UInt32 Id { get; set; } = default!;

    /// <summary>
    /// Workplace Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Workplace Description (Optional).
    /// </summary>
    public System.String? Description { get; set; }

    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public System.String? Greeting { get; set; }

    /// <summary>
    /// Workplace Workplace country ZeroOrOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64? BelongsToCountryId { get; set; } = default!;
    public virtual CountryDto? BelongsToCountry { get; set; } = null!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}