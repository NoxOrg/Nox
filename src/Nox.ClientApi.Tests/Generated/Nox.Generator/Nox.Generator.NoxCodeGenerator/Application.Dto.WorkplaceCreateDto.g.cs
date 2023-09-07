// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Workplace.
/// </summary>
public partial class WorkplaceCreateDto : IEntityCreateDto <Workplace>
{    
    /// <summary>
    /// Workplace Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;    
    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public System.String? Greeting { get; set; }   
}