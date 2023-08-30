// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record StoreKeyDto(System.String keyId);

/// <summary>
/// Stores.
/// </summary>
public partial class StoreDto
{

    /// <summary>
    /// Store Primary Key (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Physical Money in the Physical Store (Required).
    /// </summary>
    public MoneyDto PhysicalMoney { get; set; } = default!;

    /// <summary>
    /// Store Set of passwords for this store ExactlyOne StoreSecurityPasswords
    /// </summary>
    public virtual StoreSecurityPasswordsDto StoreSecurityPasswords { get; set; } = null!;

    public bool? Deleted { get; set; }

    public Store ToEntity()
    {
        var entity = new Store();
        entity.Id = Store.CreateId(Id);
        entity.Name = Store.CreateName(Name);
        entity.PhysicalMoney = Store.CreatePhysicalMoney(PhysicalMoney);
        return entity;
    }
}