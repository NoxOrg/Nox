// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleWebApp.Application.Dto; 

/// <summary>
/// Entity to test all nox types.
/// </summary>
public partial class AllNoxTypeCreateDto : AllNoxTypeUpdateDto
{
    /// <summary>
    /// Second Text Id (Required).
    /// </summary>
    [Required(ErrorMessage = "TextId is required")]
    public System.String TextId { get; set; } = default!;
}