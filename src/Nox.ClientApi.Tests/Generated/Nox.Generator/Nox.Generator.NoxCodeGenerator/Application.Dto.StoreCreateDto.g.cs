// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Stores.
/// </summary>
public partial class StoreCreateDto : StoreUpdateDto
{

    public Store ToEntity()
    {
        var entity = new Store();
        entity.Name = Store.CreateName(Name);
        //entity.StoreOwner = StoreOwner?.ToEntity();
        //entity.EmailAddress = EmailAddress?.ToEntity();
        return entity;
    }
}