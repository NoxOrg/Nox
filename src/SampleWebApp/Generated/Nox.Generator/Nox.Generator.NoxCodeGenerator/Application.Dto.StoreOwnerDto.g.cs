// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;

using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record StoreOwnerKeyDto(System.String keyId);

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwnerDto
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// StoreOwner Set of stores that this owner owns ZeroOrMany Stores
    /// </summary>
    public virtual List<StoreDto> Stores { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }    
}