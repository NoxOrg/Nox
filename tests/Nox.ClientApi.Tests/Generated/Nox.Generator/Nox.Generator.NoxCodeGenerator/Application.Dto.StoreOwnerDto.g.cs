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

    public StoreOwner ToEntity()
    {
        var entity = new StoreOwner();
        entity.Id = StoreOwner.CreateId(Id);
        entity.Name = StoreOwner.CreateName(Name);
        entity.Stores = Stores.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }

}