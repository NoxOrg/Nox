// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IamApi.Application.Dto; 

/// <summary>
/// Verified Phone.
/// </summary>
public partial class PhoneCreateDto : PhoneUpdateDto
{
    /// <summary>
    /// Phone (Required).
    /// </summary>
    [Required(ErrorMessage = "PhoneNumber is required")]
    public System.String PhoneNumber { get; set; } = default!;
}