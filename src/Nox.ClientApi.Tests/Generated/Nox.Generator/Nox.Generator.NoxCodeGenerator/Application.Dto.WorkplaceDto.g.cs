// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record WorkplaceKeyDto(System.Guid keyId);

/// <summary>
/// Workplace.
/// </summary>
public partial class WorkplaceDto
{

    /// <summary>
    /// Workplace unique identifier (Required).
    /// </summary>
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Workplace Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public System.String? Greeting { get; set; }

    public Workplace ToEntity()
    {
        var entity = new Workplace();
        entity.Id = Workplace.CreateId(Id);
        entity.Name = Workplace.CreateName(Name);
        return entity;
    }

}