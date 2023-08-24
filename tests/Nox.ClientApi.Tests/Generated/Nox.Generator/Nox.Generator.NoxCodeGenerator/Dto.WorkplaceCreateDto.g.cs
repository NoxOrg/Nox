// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientApi.Application.Dto; 

/// <summary>
/// Workplace.
/// </summary>
public partial class WorkplaceCreateDto : WorkplaceUpdateDto
{
    /// <summary>
    /// Workplace unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.Guid Id { get; set; } = default!;
}