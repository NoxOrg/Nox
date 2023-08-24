// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using ClientApi.Application.DataTransferObjects;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public class WorkplaceKeyDto
{

    /// <summary>
    /// Workplace unique identifier (Required).
    /// </summary>
    public System.Guid Id { get; set; } = default!;
}

/// <summary>
/// Workplace.
/// </summary>
public partial class WorkplaceDto : WorkplaceKeyDto
{

    /// <summary>
    /// Workplace Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;
}