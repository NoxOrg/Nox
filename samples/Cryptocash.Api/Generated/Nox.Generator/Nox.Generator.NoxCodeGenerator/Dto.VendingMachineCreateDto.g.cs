// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto; 

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachineCreateDto : VendingMachineUpdateDto
{
    /// <summary>
    /// The vending machine unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.Guid Id { get; set; } = default!;
}