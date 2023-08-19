// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientApi.Application.Dto; 

/// <summary>
/// Client Nuid Key.
/// </summary>
public partial class ClientNuidUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
}