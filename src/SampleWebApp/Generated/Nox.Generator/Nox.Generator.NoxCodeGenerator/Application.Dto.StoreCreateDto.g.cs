// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// Stores.
/// </summary>
public partial class StoreCreateDto : StoreUpdateDto
{
    /// <summary>
    /// Store Primary Key (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;

    public Store ToEntity()
    {
        var entity = new Store();
        entity.Id = Store.CreateId(Id);
        entity.Name = Store.CreateName(Name);
        entity.PhysicalMoney = Store.CreatePhysicalMoney(PhysicalMoney);
        //entity.StoreSecurityPasswords = StoreSecurityPasswords.ToEntity();
        //entity.StoreOwner = StoreOwner?.ToEntity();
        return entity;
    }
}