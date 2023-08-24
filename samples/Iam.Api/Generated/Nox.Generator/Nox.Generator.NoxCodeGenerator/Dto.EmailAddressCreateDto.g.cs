// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IamApi.Application.Dto; 

/// <summary>
/// Verified Email Address.
/// </summary>
public partial class EmailAddressCreateDto : EmailAddressUpdateDto
{
    /// <summary>
    /// Email (Required).
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    public System.String Email { get; set; } = default!;
}