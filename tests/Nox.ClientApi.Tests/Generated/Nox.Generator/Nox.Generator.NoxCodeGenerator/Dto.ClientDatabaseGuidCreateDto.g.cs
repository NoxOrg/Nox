// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientApi.Application.Dto; 

/// <summary>
/// Client DatabaseGuid Key.
/// </summary>
public partial class ClientDatabaseGuidCreateDto : ClientDatabaseGuidUpdateDto
{
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.Guid Id { get; set; } = default!;
}