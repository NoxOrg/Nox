// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using ClientApi.Application.DataTransferObjects;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record ClientDatabaseGuidKeyDto(System.Guid keyId);

/// <summary>
/// Client DatabaseGuid Key.
/// </summary>
public partial class ClientDatabaseGuidDto
{

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// The Text (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;
}