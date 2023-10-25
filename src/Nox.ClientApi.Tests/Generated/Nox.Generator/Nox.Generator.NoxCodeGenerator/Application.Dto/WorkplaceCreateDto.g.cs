// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

public partial class WorkplaceCreateDto : WorkplaceCreateDtoBase
{

}

/// <summary>
/// Workplace.
/// </summary>
public abstract class WorkplaceCreateDtoBase : IEntityDto<DomainNamespace.Workplace>
{
    /// <summary>
    /// Workplace Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Workplace Description (Optional).
    /// </summary>
    public virtual System.String? Description { get; set; }
    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public virtual System.String? Greeting { get; set; }

    /// <summary>
    /// Workplace Workplace country ZeroOrOne Countries
    /// </summary>
    public System.Int64? BelongsToCountryId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CountryCreateDto? BelongsToCountry { get; set; } = default!;
}