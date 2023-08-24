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

public class StoreKeyDto
{

    /// <summary>
    /// NuidField Type (Required).
    /// </summary>
    public System.UInt32 Id { get; set; } = default!;
}

/// <summary>
/// Stores.
/// </summary>
public partial class StoreDto : StoreKeyDto
{

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddressDto ? EmailAddress { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}