// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using ClientApi.Application.DataTransferObjects;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record ClientNuidKeyDto(System.UInt32 keyId);

/// <summary>
/// Client Nuid Key.
/// </summary>
public partial class ClientNuidDto
{

    /// <summary>
    /// NuidField Type (Required).
    /// </summary>
    public System.UInt32 Id { get; set; } = default!;

    /// <summary>
    /// The Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    public bool? Deleted { get; set; }

    public ClientNuid ToEntity()
    {
        var entity = new ClientNuid();
        entity.Id = ClientNuid.CreateId(Id);
        entity.Name = ClientNuid.CreateName(Name);
        return entity;
    }
}