// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Workplace.
/// </summary>
public partial class WorkplaceUpdateDto : IEntityDto<Workplace>
{
    /// <summary>
    /// Workplace Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Workplace Description (Optional).
    /// </summary>
    public System.String? Description { get; set; }

    /// <summary>
    /// Workplace Workplace country ZeroOrOne Countries
    /// </summary>
    
    public System.Int64? BelongsToCountryId { get; set; } = default!;
}