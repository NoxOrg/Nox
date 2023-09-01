// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
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

    /// <summary>
    /// Store Store owner relationship ZeroOrOne StoreOwners
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? StoreOwnerId { get; set; } = default!;
    public virtual StoreOwnerDto? StoreOwner { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    public Store ToEntity()
    {
        var entity = new Store();
        entity.Id = Store.CreateId(Id);
        entity.Name = Store.CreateName(Name);
        entity.PhysicalMoney = Store.CreatePhysicalMoney(PhysicalMoney);
        entity.StoreSecurityPasswords = StoreSecurityPasswords.ToEntity();
        entity.StoreOwner = StoreOwner?.ToEntity();
        return entity;
    }

}