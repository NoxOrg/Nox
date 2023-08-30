// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleWebApp.Application.Dto; 

/// <summary>
/// Stores.
/// </summary>
public partial class StoreUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Store Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Physical Money in the Physical Store (Required).
    /// </summary>
    [Required(ErrorMessage = "PhysicalMoney is required")]
    
    public MoneyDto PhysicalMoney { get; set; } = default!;
}