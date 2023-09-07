// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record WorkplaceKeyDto(System.UInt32 keyId);

/// <summary>
/// Workplace.
/// </summary>
public partial class WorkplaceDto
{

    /// <summary>
    /// Workplace unique identifier (Required).
    /// </summary>
    public System.UInt32 Id { get; set; } = default!;

    /// <summary>
    /// Workplace Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public System.String? Greeting { get; set; }    
}