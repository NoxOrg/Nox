// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientApi.Application.Dto; 

/// <summary>
/// OwnedEntity.
/// </summary>
public partial class OwnedEntityUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The Text (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
}