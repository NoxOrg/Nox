// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IamApi.Application.Dto; 

/// <summary>
/// User.
/// </summary>
public partial class UserIamCreateDto : UserIamUpdateDto
{
    /// <summary>
    /// The Customer unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.Guid Id { get; set; } = default!;
}