﻿// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record StoreKeyDto(System.UInt32 keyId);

/// <summary>
/// Stores.
/// </summary>
public partial class StoreDto
{

    /// <summary>
    /// NuidField Type (Required).
    /// </summary>
    public System.UInt32 Id { get; set; } = default!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddressDto? EmailAddress { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    public Store ToEntity()
    {
        var entity = new Store();
        entity.Id = Store.CreateId(Id);
        entity.Name = Store.CreateName(Name);
        entity.EmailAddress = EmailAddress?.ToEntity();
        return entity;
    }

}